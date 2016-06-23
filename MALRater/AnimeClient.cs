using MALRater.Data;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Facade;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        public AnimeRatings Ratings { get; set; }
            = new AnimeRatings();
        public MyAnimeList MALList { get; set; }
        public Stack<MalAnime> UnRated { get; set; }
            = new Stack<MalAnime>();
        public SearchMethods Search { get; set; }

        public void MALLogin(string username, string password)
        {
            var credentials = new CredentialContext { UserName = username, Password = password };
            Search = new SearchMethods(credentials);
            new AccountMethods(credentials).VerifyCredentials();
        }

        public void LoadList(string path)
        {
            var serializer = new XmlSerializer(typeof(MyAnimeList));
            using (var stream = new FileStream(path, FileMode.Open))
            {
                MALList = (MyAnimeList)serializer.Deserialize(stream);
            }

            FindUnrated();
        }

        public void SaveList(string path)
        {
            var serializer = new XmlSerializer(typeof(MyAnimeList));
            using (var output = new FileStream(path, FileMode.OpenOrCreate))
            {
                serializer.Serialize(output, MALList);
            }
        }

        public void LoadRatings(string path)
        {
            Ratings = JsonConvert.DeserializeObject<AnimeRatings>(File.ReadAllText(path));
            if (Ratings == null)
                Ratings = new AnimeRatings();

            if (MALList != null)
                FindUnrated();
        }

        public void SaveRatings(string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(Ratings, Formatting.Indented));
        }

        public AnimeRater GetRater()
        {
            if (MALList == null || Ratings == null)
                return null;

            return new AnimeRater(this);
        }

        public void GiveScores()
        {
            var rated = Ratings.Rated;
            var unrated = Ratings.DontRate;
            var malanimes = MALList.Anime;

            for (var i = 0; i < rated.Count; i++)
            {
                var anime = malanimes.Find(a => a.SeriesAnimedbId == rated[i].Id);
                var score = (int)Math.Ceiling(i / (rated.Count / 10.0));

                if (score == 0)
                    score = 1;

                anime.UpdateOnImport = (score != anime.MyScore) ? 1 : 0;
                anime.MyScore = score;
            }

            foreach (var unratedAnime in unrated)
            {
                var anime = malanimes.Find(a => a.SeriesAnimedbId == unratedAnime.Id);
                anime.UpdateOnImport = (0 != anime.MyScore) ? 1 : 0;
                anime.MyScore = 0;
            }
        }

        void FindUnrated()
        {
            UnRated = new Stack<MalAnime>(MALList.Anime
                .Where(a => a.MyStatus != "Watching" && 
                            a.MyStatus != "Plan to Watch" &&
                            Ratings.Rated.All(ar => ar.Id != a.SeriesAnimedbId) &&
                            Ratings.DontRate.All(ar => ar.Id != a.SeriesAnimedbId)));
        }
    }
}
