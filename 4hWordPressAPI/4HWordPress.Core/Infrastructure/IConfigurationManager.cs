using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4HWordPress.Core.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConfigurationManager
    {
        /// <summary>
        /// Get Application Title
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Get Applciation Version
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Get Applciation URL
        /// </summary>
        string ApplicationURL { get; }

        /// <summary>
        /// Get Route to Access Swagger
        /// </summary>
        string SwaggerRoutePrefix { get; }

        /// <summary>
        /// Gets the route prefix.
        /// </summary>
        string RoutePrefix { get; }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>
        string ConnectionString { get; }

        /// <summary>
        /// 
        /// </summary>
        string WebRootPath { get; }
    }
}
