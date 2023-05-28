using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4HWordPress.Core.Domain
{
    public class PublishedActivityModel
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

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        /// <value>
        /// The Status.
        /// </value>
        public string? Status { get; set; }

    }
}
