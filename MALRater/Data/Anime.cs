using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAnimeListSharp.Core;

namespace MALRater.Data
{
    public class Anime
    {
        public AnimeEntry MalEntry { get; set; }

        int _myscore;
        public int MyScore {
            get { return _myscore; }
            set
            {
                Updated = true;
                _myscore = value;
            }
        }
        public bool Updated { get; set; }
    }
}
