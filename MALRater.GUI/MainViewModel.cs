using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MyAnimeListSharp.Core;
using Newtonsoft.Json;
using MALRater.Data;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Facade;

namespace MALRater.GUI
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<AnimeEntry> RatedAnimes
        {
            get { return _ratedAnimes; }
            set
            {
                _ratedAnimes = value;
                OnPropertyChanged(nameof(RatedAnimes));
            }
        }
        ObservableCollection<AnimeEntry> _ratedAnimes;

        public ObservableCollection<AnimeEntry> UnRatedAnimes
        {
            get { return _unRatedAnimes; }
            set
            {
                _unRatedAnimes = value;
                OnPropertyChanged(nameof(UnRatedAnimes));
            }
        }
        ObservableCollection<AnimeEntry> _unRatedAnimes;

        public AnimeEntry Left
        {
            get { return _left; }
            set
            {
                _left = value;
                RightClick.OnCanExecuteChanged();
                LeftClick.OnCanExecuteChanged();
                MiddleClick.OnCanExecuteChanged();
                DontRateCommand.OnCanExecuteChanged();
                OnPropertyChanged(nameof(Left));
            }
        }
        AnimeEntry _left;

        public AnimeEntry Right
        {
            get { return _right; }
            set
            {
                _right = value;
                RightClick.OnCanExecuteChanged();
                LeftClick.OnCanExecuteChanged();
                MiddleClick.OnCanExecuteChanged();
                DontRateCommand.OnCanExecuteChanged();
                OnPropertyChanged(nameof(Right));
            }
        }
        AnimeEntry _right;

        public string Something
        {
            get { return _something; }
            set
            {
                _something = value;
                OnPropertyChanged(nameof(Something));
            }
        }
        string _something = "Start";

        public string DontRate
        {
            get { return _dontRate; }
            set
            {
                _dontRate = value;
                OnPropertyChanged(nameof(DontRate));
            }
        }
        string _dontRate;

        public DelegateCommand LeftClick { get; set; }
        public DelegateCommand RightClick { get; set; }
        public DelegateCommand MiddleClick { get; set; }
        public DelegateCommand DontRateCommand { get; set; }
        public DelegateCommand StopCommand { get; set; }

        bool _running;
        int _start;
        int _end;
        int _index;
        int _current;
        MyAnimeList _list;
        readonly SearchMethods _search = new SearchMethods(new CredentialContext
        {
            UserName = ConfigurationManager.AppSettings.Get("MALUserName"),
            Password = ConfigurationManager.AppSettings.Get("MALPassword")
        });

        public MainViewModel()
        {
            LeftClick = new DelegateCommand(LeftClickExecute, LeftClickCanExecute);
            RightClick = new DelegateCommand(RightClickExecute, RightClickCanExecute);
            MiddleClick = new DelegateCommand(MiddleClickExecute, MiddleClickCanExecute);
            DontRateCommand = new DelegateCommand(DontRateCommandExecute, DontRateCommandCanExecute);
            StopCommand = new DelegateCommand(StopCommandExecute, StopCommandCanExecute);
        }

        bool StopCommandCanExecute(object arg)
        {
            return _running;
        }

        void StopCommandExecute(object obj)
        {
            Done();
        }

        bool DontRateCommandCanExecute(object arg)
        {
            return _running && Left != null && Right != null;
        }

        void DontRateCommandExecute(object obj)
        {
            UnRatedAnimes.Add(Left);

            GetNextAnime();

            if (_running)
                GetNextCompare();
        }

        bool MiddleClickCanExecute(object arg)
        {
            return !_running || (Left != null && Right != null);
        }

        void MiddleClickExecute(object obj)
        {
            if (_running)
            {
                RatedAnimes.Insert(_index, Left);
                
                GetNextAnime();

                if (_running)
                    GetNextCompare();
            }
            else
            {
                var serializer = new XmlSerializer(typeof(MyAnimeList));

                Something = "About the same";
                _running = true;
                StopCommand.OnCanExecuteChanged();

                if (File.Exists(@"D:\Users\Jimmi\Documents\MEGA\Anime Rating\rated.json"))
                    RatedAnimes = JsonConvert.DeserializeObject<ObservableCollection<AnimeEntry>>(File.ReadAllText(@"D:\Users\Jimmi\Documents\MEGA\Anime Rating\rated.json"));
                if (RatedAnimes == null)
                    RatedAnimes = new ObservableCollection<AnimeEntry>();

                if (File.Exists(@"D:\Users\Jimmi\Documents\MEGA\Anime Rating\unrated.json"))
                    UnRatedAnimes = JsonConvert.DeserializeObject<ObservableCollection<AnimeEntry>>(File.ReadAllText(@"D:\Users\Jimmi\Documents\MEGA\Anime Rating\unrated.json"));
                if (UnRatedAnimes == null)
                    UnRatedAnimes = new ObservableCollection<AnimeEntry>();

                using (var stream = new FileStream(@"D:\Users\Jimmi\Downloads\old.xml", FileMode.Open))
                {
                    _list = (MyAnimeList)serializer.Deserialize(stream);
                }

                _current = 0;

                GetNextAnime();

                if (_running)
                    GetNextCompare();
            }
        }

        bool RightClickCanExecute(object arg)
        {
            return _running && Left != null && Right != null;
        }

        void RightClickExecute(object obj)
        {
            _end = _index;
            GetNext();
        }

        bool LeftClickCanExecute(object arg)
        {
            return _running && Left != null && Right != null;
        }

        void LeftClickExecute(object obj)
        {
            _start = _index + 1;
            GetNext();
        }

        void GetNext()
        {
            if (_start == _end)
            {
                RatedAnimes.Insert(_start, Left);
                GetNextAnime();
            }

            if (_running)
                GetNextCompare();
        }

        void GetNextCompare()
        {
            if (RatedAnimes.Count == 0)
            {
                RatedAnimes.Add(Left);
                GetNextAnime();
            }

            _index = _start + (_end - _start) /2;
            Right = RatedAnimes[_index];
        }

        void GetNextAnime()
        {
            _start = 0;
            _end = RatedAnimes.Count;

            for (;; _current++)
            {
                if (_current >= _list.Anime.Count)
                {
                    Done();
                    break;
                }

                var entry = _list.Anime[_current];
                if (RatedAnimes.All(a => a.Id != entry.SeriesAnimedbId) &&
                    UnRatedAnimes.All(a => a.Id != entry.SeriesAnimedbId))
                {
                    Left = _search.SearchAnimeDeserialized(entry.SeriesTitle).Entries.First(a => a.Id == entry.SeriesAnimedbId);
                    DontRate = "Dont rate " + Left.Title;
                    break;
                }
            }

            _current++;
        }

        void Done()
        {
            var serializer = new XmlSerializer(typeof(MyAnimeList));
            _running = false;
            StopCommand.OnCanExecuteChanged();
            Something = "Start";
            Left = null;
            Right = null;

            for (var i = 0; i < RatedAnimes.Count; i++)
            {
                var rating = _list.Anime.Find(a => a.SeriesAnimedbId == RatedAnimes[i].Id);
                var score = (int)Math.Ceiling(i / (RatedAnimes.Count / 10.0));

                if (score == 0)
                    score = 1;

                rating.UpdateOnImport = (score != rating.MyScore) ? 1 : 0;
                rating.MyScore = score;
            }

            foreach (var anime in UnRatedAnimes)
            {
                var rating = _list.Anime.Find(a => a.SeriesAnimedbId == anime.Id);
                rating.UpdateOnImport = (0 != rating.MyScore) ? 1 : 0;
                rating.MyScore = 0;
            }

            using (var output = new FileStream(@"D:\Users\Jimmi\Downloads\new.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(output, _list);
            }

            File.WriteAllText(@"D:\Users\Jimmi\Documents\MEGA\Anime Rating\rated.json", JsonConvert.SerializeObject(RatedAnimes, Formatting.Indented));
            File.WriteAllText(@"D:\Users\Jimmi\Documents\MEGA\Anime Rating\unrated.json", JsonConvert.SerializeObject(UnRatedAnimes, Formatting.Indented));
        }
    }
}
