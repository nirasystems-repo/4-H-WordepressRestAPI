using _4HWordPress.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4HWordPress.Core.IRepositories
{
    public interface IPublishedActivityRepository
    {
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<List<PublishedActivityModel>> GetAsync();

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="publishedActivityModel">The test model.</param>
        /// <returns></returns>
        Task AddPublishedActivityAsync(PublishedActivityModel publishedActivityModel);
        
        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="publishedActivityModel">The test model.</param>
        /// <returns></returns>
        Task AddLguExtentionAsync(LguExtentionModel lguExtention);
        
        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="publishedActivityModel">The test model.</param>
        /// <returns></returns>
        Task AddUsersAsync(UsersModel Users);

    }
}