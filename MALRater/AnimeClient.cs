using MALRater.Data;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Facade;
using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MyAnimeListSharp.Enums;
using RestSharp;

namespace MALRater
{
    public class AnimeClient
    {
        public class AnimeRatings
        {
            public List<AnimeEntry> Rated { get; set; } 
                = new List<AnimeEntry>();
            public List<AnimeEntry> DontRate { get; set; } 
                = new List<AnimeEntry>();
        }

        public AnimeListMethods AnimeListMethods { get; }
        public SearchMethods SearchMethods { get; set; }

        public AnimeRatings Ratings { get; set; } = new AnimeRatings();
        public Stack<MalAnime> UnRated { get; set; } = new Stack<MalAnime>();
        public MyAnimeList MyAnimeList { get; private set; }

        public AnimeClient(string username, string password)
        {
            var credentials = new CredentialContext { UserName = username, Password = password };
            SearchMethods = new SearchMethods(credentials);
            AnimeListMethods = new AnimeListMethods(credentials);
            new AccountMethods(credentials).VerifyCredentials();
        }

        public void LoadList(string path)
        {
            var serializer = new XmlSerializer(typeof(MyAnimeList));

            using (var stream = new FileStream(path, FileMode.Open))
            {
                MyAnimeList = (MyAnimeList)serializer.Deserialize(stream);
            }

            FindUnrated();
        }

        public void LoadRatings(string path)
        {
            Ratings = JsonConvert.DeserializeObject<AnimeRatings>(File.ReadAllText(path));
            if (Ratings == null)
                Ratings = new AnimeRatings();

            if (MyAnimeList != null)
                FindUnrated();
        }

        public void SaveRatings(string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(Ratings, Formatting.Indented));
        }

        public AnimeRater GetRater()
        {
            if (MyAnimeList == null || Ratings == null)
                return null;

            return new AnimeRater(this);
        }

        public void GiveScores()
        {
            var rated = Ratings.Rated;
            var unrated = Ratings.DontRate;
            var malanimes = MyAnimeList.Anime;

            for (var i = 0; i < rated.Count; i++)
            {
                var anime = malanimes.Find(a => a.SeriesAnimedbId == rated[i].Id);
                var score = (int)Math.Ceiling(i / (rated.Count / 10.0));

                if (score == 0)
                    score = 1;

                if (score != anime.MyScore)
                {
                    AnimeListMethods.UpdateAnime(anime.SeriesAnimedbId, new AnimeValues
                    {
                        AnimeStatus = StringToStatus(anime.MyStatus),
                        //Comments = null,
                        //DateFinish = null,
                        //DateStart = null,
                        //DownloadedEpisodes = 0,
                        //EnableDiscussion = EnableDiscussion.Disable,
                        //EnableRewatching = EnableRewatching.Disable,
                        Episode = (short)anime.MyWatchedEpisodes,
                        //FansubGroup = null,
                        //Priority = Priority.Low,
                        //RewatchValue = 0,
                        //StorageType = 0,
                        //StorageValue = 0,
                        TimesRewatched = anime.MyTimesWatched,
                        Score = (Score)score,
                        //Tags = null
                    });
                }

                anime.UpdateOnImport = (score != anime.MyScore) ? 1 : 0;
                anime.MyScore = score;
            }

            foreach (var unratedAnime in unrated)
            {
                var anime = malanimes.Find(a => a.SeriesAnimedbId == unratedAnime.Id);
                
                if (0 != anime.MyScore)
                {
                    AnimeListMethods.UpdateAnime(anime.SeriesAnimedbId, new AnimeValues
                    {
                        AnimeStatus = StringToStatus(anime.MyStatus),
                        //Comments = null,
                        //DateFinish = null,
                        //DateStart = null,
                        //DownloadedEpisodes = 0,
                        //EnableDiscussion = EnableDiscussion.Disable,
                        //EnableRewatching = EnableRewatching.Disable,
                        Episode = (short)anime.MyWatchedEpisodes,
                        //FansubGroup = null,
                        //Priority = Priority.Low,
                        //RewatchValue = 0,
                        //StorageType = 0,
                        //StorageValue = 0,
                        TimesRewatched = anime.MyTimesWatched,
                        Score = (Score)anime.MyScore,
                        //Tags = null
                    });
                }

                anime.UpdateOnImport = (0 != anime.MyScore) ? 1 : 0;
                anime.MyScore = 0;
            }
        }

        void FindUnrated()
        {
            UnRated = new Stack<MalAnime>(MyAnimeList.Anime
                .Where(a =>
                {
                    var status = StringToStatus(a.MyStatus);
                    return status != AnimeStatus.Watching &&
                           status != AnimeStatus.PlanToWatch &&
                           Ratings.Rated.All(ar => ar.Id != a.SeriesAnimedbId) &&
                           Ratings.DontRate.All(ar => ar.Id != a.SeriesAnimedbId);
                }));
        }

        AnimeStatus StringToStatus(string str)
        {
            if (str == "Watching" || str == "1")
            {
                return AnimeStatus.Watching;
            }
            else if (str == "Plan to Watch" || str == "6")
            {
                return AnimeStatus.PlanToWatch;
            }
            else if (str == "On Hold" || str == "5")
            {
                return AnimeStatus.OnHold;
            }
            else if (str == "Completed" || str == "2")
            {
                return AnimeStatus.Completed;
            }
            else if (str == "Dropped" || str == "4")
            {
                return AnimeStatus.Dropped;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
