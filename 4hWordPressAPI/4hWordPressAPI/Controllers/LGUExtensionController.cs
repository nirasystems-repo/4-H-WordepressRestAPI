﻿using _4HWordPress.Core.Common;
using _4HWordPress.Core.Domain;
using _4HWordPress.Core.Dto;
using _4HWordPress.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using RestSharp.Authenticators;
using WordPressPCL;

namespace _4hWordPressAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LGUExtensionController : ControllerBase
    {
        /// <summary>
        /// The job service
        /// </summary>
        private readonly IPublishedActivityService _publishedActivityService;

        /// <summary>
        /// The logger
        /// </summary>
        //private readonly ILogger _logger;
        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobController"/> class.
        /// </summary>
        /// <param name="publishedActivityService">The job service.</param>
        /// <param name="logger">The logger.</param>
        public LGUExtensionController(IPublishedActivityService publishedActivityService, ILogger<WeatherForecastController> logger)
        {
            _publishedActivityService = publishedActivityService;
            _logger = logger;
        }

        #region Get

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {

                var token = GetToken();
                if (null == token)
                {
                    return StatusCode((int)HttpStatusCode.NotFound, 
                        new ResponseData { Message = Messages.NotFound });
                }
                var result = await GetLguExtension();
                return StatusCode((int)result.Code, result.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"JobController:GetAsync:- {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new ResponseData { Message = Messages.InternalServerError });
            }
        }

        #endregion

        public async Task<APIResponse> GetLguExtension()
        {
            List<LguExtentionModel> lguExtentions = new List<LguExtentionModel>();
            List<LguExtentionModel> totalLguExtentions = new List<LguExtentionModel>();

            try
            {
                HttpClient httpClient = new HttpClient();
                int offset = 0;
                int PerPage = 100;
                do
                {
                    var extractURL = $"https://4-h.org/wp-json/wp/v2/extension-lgu?per_page={PerPage}&offset={offset}";
                    offset = offset + PerPage;
                    HttpResponseMessage extractResponse = httpClient.GetAsync(extractURL).Result;
                    var extract = extractResponse.Content.ReadAsStringAsync().Result;
                    lguExtentions = JsonConvert.DeserializeObject<List<LguExtentionModel>>(extract);
                    foreach (var lguExtention in lguExtentions)
                    {
                        totalLguExtentions.Add(lguExtention);
                    }
                }
                while (lguExtentions.Count > 0);
                return new APIResponse(totalLguExtentions, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError($"JobController:GetAsync:- {ex}");
                return new APIResponse(lguExtentions, HttpStatusCode.OK);
            }
            
            //publishedActivityModel.Id = extract.
        }
       
        public string GetToken()
        {
            HttpClient httpClient = new HttpClient();

            // Get Token
            httpClient.BaseAddress = new Uri("https://4-h.org/?oauth=token");
            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("client_id", "7f9NFx7MZ3TK8mknujsz6wcy0QVH5YBimEMd00Z2"));
            postData.Add(new KeyValuePair<string, string>("client_secret", "y5M87EGD5w8Ax507m3ynRbDlS09YB9TeJjDNJm8A"));
            postData.Add(new KeyValuePair<string, string>("scope", "basic"));
            postData.Add(new KeyValuePair<string, string>("token_type", "Bearer"));
            postData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

            HttpResponseMessage tokenResponse = httpClient.PostAsync(httpClient.BaseAddress, new FormUrlEncodedContent(postData)).Result;
            var result = tokenResponse.Content.ReadAsStringAsync().Result;
            var tokenResult = JsonConvert.DeserializeObject<dynamic>(result);
            if(null == tokenResult)
            {
                return null;
            }
            var token = tokenResult.access_token.Value.ToString();
            return token;
        }

    }
}
