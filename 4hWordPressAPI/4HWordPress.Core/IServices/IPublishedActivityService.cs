using _4HWordPress.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4HWordPress.Core.IServices
{
    public interface IPublishedActivityService
    {
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<APIResponse> GetAsync();

        // <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="PublishedActivityModel">The user dto.</param>
        /// <returns></returns>
        Task<APIResponse> AddPublishedActivityAsync(PublishedActivityModel publishedActivity);
        
        // <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="PublishedActivityModel">The user dto.</param>
        /// <returns></returns>
        Task<APIResponse> AddLguExtentionAsync(LguExtentionModel lguExtention);
        
        // <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="PublishedActivityModel">The user dto.</param>
        /// <returns></returns>
        Task<APIResponse> AddUsersAsync(UsersModel Users);
        
    }
}
