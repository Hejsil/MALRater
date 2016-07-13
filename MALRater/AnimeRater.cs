using MALRater.Data;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALRater
{
    public class AnimeRater
    {
        public AnimeClient Client { get; }
        public AnimeWrapper CurrentlyRating { get; private set; }
        public AnimeWrapper ComparedTo { get; private set; }
        public int ComparedToIndex { get; private set; }
        public int StartIndex { get; private set; }
        public int EndIndex { get; private set; }
        public bool IsDone { get; private set; }

        List<AnimeWrapper> Rated => Client.Ratings.Rated;
        List<AnimeWrapper> DontRate => Client.Ratings.DontRate;
        Stack<MalAnime> UnRated => Client.UnRated;
        List<MalAnime> MALAnimes => Client.MALList.Anime;
        SearchMethods Search => Client.Search;

        public AnimeRater(AnimeClient client)
        {
            Client = client;

            GetNextCurrent();

            if (!IsDone)
                GetNextCompareTo();
        }

        public void Choose(Choice choice)
        {
            switch (choice)
            {
                case Choice.DontRate:
                    DontRate.Add(CurrentlyRating);
                    UnRated.Pop();
                    GetNextCurrent();
                    break;
                case Choice.AboutEqual:
                    Rated.Insert(ComparedToIndex, CurrentlyRating);
                    UnRated.Pop();

                    GetNextCurrent();

                    if (!IsDone)
                        GetNextCompareTo();
                    break;
                case Choice.CurrentIsBetter:
                    StartIndex = ComparedToIndex + 1;
                    GetNext();
                    break;
                case Choice.CurrentIsWorse:
                    EndIndex = ComparedToIndex;
                    GetNext();
                    break;
                case Choice.Stop:
                    IsDone = true;
                    break;
                default:
                    break;
            }
        }

        void GetNext()
        {
            if (StartIndex == EndIndex)
            {
                Rated.Insert(StartIndex, CurrentlyRating);
                UnRated.Pop();
                GetNextCurrent();
            }

            if (!IsDone)
                GetNextCompareTo();
        }

        void GetNextCurrent()
        {
            StartIndex = 0;
            EndIndex = Rated.Count;

            if (UnRated.Count == 0)
            {
                IsDone = true;
                return;
            }

            var entry = UnRated.Peek();
            CurrentlyRating = new AnimeWrapper(Search
                .SearchAnimeDeserialized(entry.SeriesTitle)
                .Entries.First(a => a.Id == entry.SeriesAnimedbId));
        }

        void GetNextCompareTo()
        {
            if (Rated.Count == 0)
            {
                Rated.Add(CurrentlyRating);
                UnRated.Pop();
                GetNextCurrent();
            }

            ComparedToIndex = StartIndex + (EndIndex - StartIndex) / 2;
            ComparedTo = Rated[ComparedToIndex];
        }

        public enum Choice
        {
            DontRate,
            AboutEqual,
            CurrentIsBetter,
            CurrentIsWorse,
            Stop
        }
    }
}
