using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4HWordPress.Core.Domain
{
    public class PublishedActivityModel
    {
        public List<string?> activity_course_grades { get; set; }
        public List<string?> activity_type { get; set; }
        public List<string?> course_activities { get; set; }
        public List<string?> extension__lgu { get; set; }
        public string? more_activities_category { get; set; }
        public List<string?> topic { get; set; }
        public int? Id { get; set; }
        public DateTime? date { get; set; }
        public DateTime? date_gmt { get; set; }
        public DateTime? modified { get; set; }
        public DateTime? modified_gmt { get; set; }
        public string? slug { get; set; }
        public string? type { get; set; }
        //public string? title { get; set; }
        public Dictionary<string, string> title { get; set; }
        public Dictionary<string, object> acf { get; set; }
        public int? featured_media { get; set; }
        public string? template { get; set; }
        public string? topicForeign { get; set; }
        public string? activity_typeForeign { get; set; }
        public string? activity_course_gradesForeign { get; set; }
        public string? extension__lguForeign { get; set; }
        public string? course_or_activity { get; set; }
        public string? is_public_activity { get; set; }
        public string? location { get; set; }
        public string? partner { get; set; }
        public string? afri_category { get; set; }
        public string? more_activities_categoryForeign { get; set; }
        public string? course_activitiesForeign { get; set; }
        public string? course_about { get; set; }
        public string? course_sponsor_description { get; set; }
        public string? title_head { get; set; }

        ///// <summary>
        ///// Gets or sets the Id.
        ///// </summary>
        ///// <value>
        ///// The Id.
        ///// </value>
        //public int? Id { get; set; }

        ///// <summary>
        ///// Gets or sets the Date.
        ///// </summary>
        ///// <value>
        ///// The Date.
        ///// </value>
        //public DateTime? Date { get; set; }

        ///// <summary>
        ///// Gets or sets the Status.
        ///// </summary>
        ///// <value>
        ///// The Status.
        ///// </value>
        //public string? Status { get; set; }

    }
}
