using _4HWordPress.Core.Common;
using _4HWordPress.Core.Domain;
using _4HWordPress.Core.Dto;
using _4HWordPress.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace _4hWordPressAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordPressController : ControllerBase
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
        public WordPressController(IPublishedActivityService publishedActivityService, ILogger<WeatherForecastController> logger)
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
                await GetPublishedActivity(token);
                //await GetLguExtention();
                //await GetUsers(token);

                var result = await _publishedActivityService.GetAsync();
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

        public async Task<IActionResult> GetPublishedActivity(string token)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token.ToString());
                //var extractURL = "https://4-h.org/wp-json/wp/v2/activity-course?per_page=100";
                List<PublishedActivityModel> publishedActivities = new List<PublishedActivityModel>();
                int offset = 0;
                int PerPage = 100;
                do
                {
                    var extractURL = $"https://4-h.org/wp-json/wp/v2/activity-course?per_page={PerPage}&offset={offset}";
                    offset = offset + PerPage;
                    HttpResponseMessage extractResponse = httpClient.GetAsync(extractURL).Result;
                    var extract = extractResponse.Content.ReadAsStringAsync().Result;
                    publishedActivities = JsonConvert.DeserializeObject<List<PublishedActivityModel>>(extract);
                    if (publishedActivities.Count > 0)
                    {
                        foreach (var publishedActivity in publishedActivities)
                        {
                            var result = await _publishedActivityService.AddPublishedActivityAsync(publishedActivity);
                        }
                    }
                }
                while (publishedActivities.Count > 0);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"JobController:GetAsync:- {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new ResponseData { Message = Messages.InternalServerError });
            }
            
            //publishedActivityModel.Id = extract.
        }
        
        public async Task<IActionResult> GetLguExtention()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                List<LguExtentionModel> lguExtentions = new List<LguExtentionModel>();
                int offset = 0;
                int PerPage = 100;
                do
                {
                    var extractURL = $"https://4-h.org/wp-json/wp/v2/extension-lgu?per_page={PerPage}&offset={offset}";
                    offset = offset + PerPage;
                    HttpResponseMessage extractResponse = httpClient.GetAsync(extractURL).Result;
                    var extract = extractResponse.Content.ReadAsStringAsync().Result;
                    lguExtentions = JsonConvert.DeserializeObject<List<LguExtentionModel>>(extract);
                    if (lguExtentions.Count > 0)
                    {
                        foreach (var lguExtention in lguExtentions)
                        {
                            var result = await _publishedActivityService.AddLguExtentionAsync(lguExtention);
                        }
                    }
                }
                while (lguExtentions.Count > 0);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"JobController:GetAsync:- {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new ResponseData { Message = Messages.InternalServerError });
            }
            
            //publishedActivityModel.Id = extract.
        }
        
        public async Task<IActionResult> GetUsers(string token)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token.ToString());
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", "wordpress_logged_in_6e44cdcb7cec4b78" +
                    "b300b1b264e21975=kpillai%7C1685687499%7C0mvdlfQ0rKbrknoHDa9yj2VdmAvGjeP6cgu03rX9ob1%7Cf7c32cc484232d9bd31abe73236f8173183e997720da1833ae02d469eb799f70");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-WP-Nonce", "69b686167e");

                List<UsersModel> users = new List<UsersModel>();
                int offset = 0;
                int PerPage = 100;
                do
                {
                   var extractURL = $"https://4-h.org/wp-json/wp/v2/users?&context=edit&per_page={PerPage}&offset={offset}";
                    offset = offset + PerPage;
                    HttpResponseMessage extractResponse = httpClient.GetAsync(extractURL).Result;
                    var extract = extractResponse.Content.ReadAsStringAsync().Result;
                    users = JsonConvert.DeserializeObject<List<UsersModel>>(extract);
                    if (users.Count > 0)
                    {
                        foreach (var user in users)
                        {
                            var result = await _publishedActivityService.AddUsersAsync(user);
                        }
                    }
                }
                while (users.Count > 0);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"JobController:GetAsync:- {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new ResponseData { Message = Messages.InternalServerError });
            }
            
            //publishedActivityModel.Id = extract.
        }

        #region AddAsync
        ///// <summary>
        ///// Adds the asynchronous.
        ///// </summary>
        ///// <param name="interViewCallsDto">The interViewCalls dto.</param>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<IActionResult> AddPublishedActivityAsync([FromBody] PublishedActivityModel publishedActivityModel)
        //{
        //    try
        //    {
        //        var result = await _publishedActivityService.AddPublishedActivityAsync(publishedActivityModel);
        //        return StatusCode((int)result.Code, result.Data);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"WordPressController:GetAsync:- {ex}");
        //        return StatusCode((int)HttpStatusCode.InternalServerError,
        //            new ResponseData { Message = Messages.InternalServerError });
        //    }
        //}

        #endregion
        
        #region AddAsync
        ///// <summary>
        ///// Adds the asynchronous.
        ///// </summary>
        ///// <param name="interViewCallsDto">The interViewCalls dto.</param>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<IActionResult> AddLguExtentionAsync([FromBody] LguExtentionModel lguExtention)
        //{
        //    try
        //    {
        //        var result = await _publishedActivityService.AddLguExtentionAsync(lguExtention);
        //        return StatusCode((int)result.Code, result.Data);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"WordPressController:GetAsync:- {ex}");
        //        return StatusCode((int)HttpStatusCode.InternalServerError,
        //            new ResponseData { Message = Messages.InternalServerError });
        //    }
        //}

        #endregion

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
