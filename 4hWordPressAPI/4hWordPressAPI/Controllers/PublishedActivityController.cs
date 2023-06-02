using _4HWordPress.Core.Common;
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
    public class PublishedActivityController : ControllerBase
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
        public PublishedActivityController(IPublishedActivityService publishedActivityService, ILogger<WeatherForecastController> logger)
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
                var result = await GetPublishedActivity(token);
                //await GetLguExtention();
                ////await GetSubscribers(token);
                //await GetUsers(token);

                //var result = await _publishedActivityService.GetAsync();
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

        public async Task<APIResponse> GetPublishedActivity(string token)
        {
            List<PublishedActivityModel> publishedActivities = new List<PublishedActivityModel>();
            List<PublishedActivityModel> totalPublishedActivities = new List<PublishedActivityModel>();

            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token.ToString());
                int offset = 0;
                int PerPage = 100;
                do
                {
                    var extractURL = $"https://4-h.org/wp-json/wp/v2/activity-course?per_page={PerPage}&offset={offset}";
                    offset = offset + PerPage;
                    HttpResponseMessage extractResponse = httpClient.GetAsync(extractURL).Result;
                    var extract = extractResponse.Content.ReadAsStringAsync().Result;
                    publishedActivities = JsonConvert.DeserializeObject<List<PublishedActivityModel>>(extract);
                    foreach (var publishedActivity in publishedActivities)
                    {
                        totalPublishedActivities.Add(publishedActivity);
                    }

                    //if (publishedActivities.Count > 0)
                    //{
                    //    foreach (var publishedActivity in publishedActivities)
                    //    {
                    //        var result = await _publishedActivityService.AddPublishedActivityAsync(publishedActivity);
                    //    }
                    //}
                    //if (publishedActivities.Count > 0)
                    //{
                    //    foreach (var publishedActivity in publishedActivities)
                    //    {
                    //        var result = await _publishedActivityService.AddPublishedActivityAsync(publishedActivity);
                    //    }
                    //}
                }
                while (publishedActivities.Count > 0);
                return new APIResponse(totalPublishedActivities, HttpStatusCode.OK);
                //return publishedActivities;
            }
            catch (Exception ex)
            {
                _logger.LogError($"JobController:GetAsync:- {ex}");
                return new APIResponse(publishedActivities, HttpStatusCode.OK);
                //return publishedActivities;
                //return StatusCode((int)HttpStatusCode.InternalServerError,
                //new ResponseData { Message = Messages.InternalServerError });
            }
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
                    "b300b1b264e21975=kpillai%7C1685863317%7CtUgaVoPnHAzGWBRNhIyASnnoQlaP101XO0jD59oQU9e%7C04fe437dc0a886" +
                    "937b02b60713220e928bec75b8bee154046c37b5c47411d4e7");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-WP-Nonce", "aa879bd2b3");

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

        public async Task<IActionResult> GetSubscribers(string token)
        {
            try
            {
                const string consumer_key = "ck_47a9e97def1643bb6c77f06e4674d970d1bfd3db";
                const string consumer_secret = "cs_94e19e51a1f7ddd39b0fbb9bf66cd493db356524";
                ////string access_token = token;
                //const string token_secret = "";
                const string URL = "https://www.4-h.org/wp-json/wc/v1/subscriptions";


                var options = new RestClientOptions(URL);
                OAuth1Authenticator lAuthenticator = OAuth1Authenticator.ForRequestToken(consumer_key, consumer_secret,
                    RestSharp.Authenticators.OAuth.OAuthSignatureMethod.HmacSha1);
                options.Authenticator = lAuthenticator;

                var client = new RestClient(options);
                var request = new RestRequest(URL, Method.Get);
                //request.AddHeader("Content-Type", "application/text");
                request.AddHeader("queryStringAuth", "true");
                var response = client.Execute(request);
                var re = response;
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"JobController:GetAsync:- {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new ResponseData { Message = Messages.InternalServerError });
            }
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
