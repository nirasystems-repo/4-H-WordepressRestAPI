using _4HWordPress.Core.Domain;
using _4HWordPress.Core.Dto;
using _4HWordPress.Core.IRepositories;
using _4HWordPress.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _4hWordPressAPI.Application.Services
{
    public class PublishedActivityService : IPublishedActivityService
    {
        /// <summary>
        /// The publishedActivity repository
        /// </summary>
        private readonly IPublishedActivityRepository _publishedActivityRepository;

        ///// <summary>
        ///// The publishedActivity dto validator
        ///// </summary>
        //private readonly IValidator<PublishedActivityDto> _publishedActivityDtoValidator;

        ///// <summary>
        ///// The mapper
        ///// </summary>
        //private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PublishedActivityService"/> class.
        /// </summary>
        /// <param name="_publishedActivityRepository">The publishedActivity repository.</param>
        public PublishedActivityService(IPublishedActivityRepository publishedActivityRepository)
        {
            _publishedActivityRepository = publishedActivityRepository;
        }

        #region Get
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<APIResponse> GetAsync()
        {
            var a = await _publishedActivityRepository.GetAsync();
            return new APIResponse(a, HttpStatusCode.OK);
        }
        #endregion
    
    }
}
