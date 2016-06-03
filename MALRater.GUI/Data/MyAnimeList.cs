using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MALRater.Data
{
    [XmlRoot(ElementName = "myanimelist")]
    public class MyAnimeList
    {
        [XmlElement(ElementName = "myinfo")]
        public MalInfo Myinfo { get; set; }
        [XmlElement(ElementName = "anime")]
        public List<MalAnime> Anime { get; set; }
    }
}