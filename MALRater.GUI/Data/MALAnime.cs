using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MALRater.Data
{
    [XmlRoot(ElementName = "anime")]
    public class MalAnime
    {
        [XmlElement(ElementName = "series_animedb_id")]
        public int SeriesAnimedbId { get; set; }

        [XmlElement(ElementName = "series_title")]
        public string SeriesTitle { get; set; }

        [XmlElement(ElementName = "series_type")]
        public string SeriesType { get; set; }

        [XmlElement(ElementName = "series_episodes")]
        public int SeriesEpisodes { get; set; }

        [XmlElement(ElementName = "my_id")]
        public int MyId { get; set; }

        [XmlElement(ElementName = "my_watched_episodes")]
        public int MyWatchedEpisodes { get; set; }

        [XmlElement(ElementName = "my_start_date")]
        public string MyStartDate { get; set; }

        [XmlElement(ElementName = "my_finish_date")]
        public string MyFinishDate { get; set; }

        [XmlElement(ElementName = "my_rated")]
        public string MyRated { get; set; }

        [XmlElement(ElementName = "my_score")]
        public int MyScore { get; set; }

        [XmlElement(ElementName = "my_dvd")]
        public string MyDvd { get; set; }

        [XmlElement(ElementName = "my_storage")]
        public string MyStorage { get; set; }

        [XmlElement(ElementName = "my_status")]
        public string MyStatus { get; set; }

        [XmlElement(ElementName = "my_comments")]
        public string MyComments { get; set; }

        [XmlElement(ElementName = "my_times_watched")]
        public int MyTimesWatched { get; set; }

        [XmlElement(ElementName = "my_rewatch_value")]
        public string MyRewatchValue { get; set; }

        [XmlElement(ElementName = "my_tags")]
        public string MyTags { get; set; }

        [XmlElement(ElementName = "my_rewatching")]
        public int MyRewatching { get; set; }

        [XmlElement(ElementName = "my_rewatching_ep")]
        public int MyRewatchingEp { get; set; }

        [XmlElement(ElementName = "update_on_import")]
        public int UpdateOnImport { get; set; }
    }
}
