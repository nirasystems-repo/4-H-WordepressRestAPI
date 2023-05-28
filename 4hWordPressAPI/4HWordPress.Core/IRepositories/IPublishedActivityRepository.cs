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
    }
}