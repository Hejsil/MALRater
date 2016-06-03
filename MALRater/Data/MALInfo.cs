using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MALRater.Data
{
    [XmlRoot(ElementName = "myinfo")]
    public class MalInfo
    {
        [XmlElement(ElementName = "user_id")]
        public int UserId { get; set; }

        [XmlElement(ElementName = "user_name")]
        public string UserName { get; set; }

        [XmlElement(ElementName = "user_export_type")]
        public int UserExportType { get; set; }

        [XmlElement(ElementName = "user_total_anime")]
        public int UserTotalAnime { get; set; }

        [XmlElement(ElementName = "user_total_watching")]
        public int UserTotalWatching { get; set; }

        [XmlElement(ElementName = "user_total_completed")]
        public int UserTotalCompleted { get; set; }

        [XmlElement(ElementName = "user_total_onhold")]
        public int UserTotalOnhold { get; set; }

        [XmlElement(ElementName = "user_total_dropped")]
        public int UserTotalDropped { get; set; }

        [XmlElement(ElementName = "user_total_plantowatch")]
        public int UserTotalPlantowatch { get; set; }
    }
}
