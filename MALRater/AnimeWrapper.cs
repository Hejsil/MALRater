using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAnimeListSharp.Core;
using Newtonsoft.Json;

namespace MALRater
{
    public class AnimeWrapper
    {
        public int Id
        {
            get { return _entry.Id; }
            set { _entry.Id = value; }
        }

        public string Title
        {
            get { return _entry.Title; }
            set { _entry.Title = value; }
        }

        public string English
        {
            get { return _entry.English; }
            set { _entry.English = value; }
        }

        public string Image
        {
            get { return _entry.Image; }
            set { _entry.Image = value; }
        }

        readonly AnimeEntry _entry;

        public AnimeWrapper(AnimeEntry entry)
        {
            _entry = entry;
        }

        public AnimeWrapper()
            : this(new AnimeEntry())
        { }
    }
}
