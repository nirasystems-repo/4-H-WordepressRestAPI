using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4HWordPress.Core.Domain
{
    public class UsersModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        /// <value>
        /// The Id.
        /// </value>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the Username.
        /// </summary>
        /// <value>
        /// The Username.
        /// </value>
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>
        /// The Name.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the First_name.
        /// </summary>
        /// <value>
        /// The First_name.
        /// </value>
        public string? First_name { get; set; }

        /// <summary>
        /// Gets or sets the Last_name.
        /// </summary>
        /// <value>
        /// The Last_name.
        /// </value>
        public string? Last_name { get; set; }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        /// <value>
        /// The Email.
        /// </value>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>
        /// The Description.
        /// </value>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the Link.
        /// </summary>
        /// <value>
        /// The Link.
        /// </value>
        public string? Link { get; set; }

        /// <summary>
        /// Gets or sets the Nickname.
        /// </summary>
        /// <value>
        /// The Nickname.
        /// </value>
        public string? Nickname { get; set; }

        /// <summary>
        /// Gets or sets the Slug.
        /// </summary>
        /// <value>
        /// The Slug.
        /// </value>
        public string? Slug { get; set; }

        /// <summary>
        /// Gets or sets the Roles.
        /// </summary>
        /// <value>
        /// The Roles.
        /// </value>
        public List<string> Roles { get; set; }

        /// <summary>
        /// Gets or sets the Registered_date.
        /// </summary>
        /// <value>
        /// The Registered_date.
        /// </value>
        public DateTime? Registered_date { get; set; }

        /// <summary>
        /// Gets or sets the Educator.
        /// </summary>
        /// <value>
        /// The Educator.
        /// </value>
        public string? Educator { get; set; }

        /// <summary>
        /// Gets or sets the Professional_resources.
        /// </summary>
        /// <value>
        /// The Professional_resources.
        /// </value>
        public string? Professional_resources { get; set; }

        /// <summary>
        /// Gets or sets the Is_super_admin.
        /// </summary>
        /// <value>
        /// The Is_super_admin.
        /// </value>
        public string? Is_super_admin { get; set; }
    }
}
