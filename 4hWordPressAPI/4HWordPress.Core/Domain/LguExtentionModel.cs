using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4HWordPress.Core.Domain
{
    public class LguExtentionModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        /// <value>
        /// The Id.
        /// </value>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the Date.
        /// </summary>
        /// <value>
        /// The Date.
        /// </value>
        public DateTime? Date { get; set; }

        // <summary>
        /// Gets or sets the Date_gmt.
        /// </summary>
        /// <value>
        /// The Date_gmt.
        /// </value>
        public DateTime? Date_gmt { get; set; }

        // <summary>
        /// Gets or sets the Modified.
        /// </summary>
        /// <value>
        /// The Modified.
        /// </value>
        public DateTime? Modified { get; set; }

        // <summary>
        /// Gets or sets the Modified_gmt.
        /// </summary>
        /// <value>
        /// The Modified_gmt.
        /// </value>
        public DateTime? Modified_gmt { get; set; }

        /// <summary>
        /// Gets or sets the Slug.
        /// </summary>
        /// <value>
        /// The Slug.
        /// </value>
        public string? Slug { get; set; }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        /// <value>
        /// The Status.
        /// </value>
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        /// <value>
        /// The Type.
        /// </value>
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        /// <value>
        /// The Title.
        /// </value>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the Title_head.
        /// </summary>
        /// <value>
        /// The Title_head.
        /// </value>
        public string? Title_head { get; set; }

    }
}
