using _4HWordPress.Core.Common;
using _4HWordPress.Core.Domain;
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
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobController"/> class.
        /// </summary>
        /// <param name="publishedActivityService">The job service.</param>
        /// <param name="logger">The logger.</param>
        public WordPressController(IPublishedActivityService publishedActivityService, ILogger logger)
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


        //private DataContext _context;

        //public WordPressController(DataContext context)
        //{
        //    _context = context;
        //}

        //[HttpGet]
        //[Obsolete]
        //public async Task<IActionResult> Get()
        //{
        //    try
        //    {
        //        using var connection = _context.CreateConnection();
        //        var query = "select*from publishedactivities;";
        //        var queryResult = await connection.QueryAsync<PublishedActivityModel>(query);

        //        HttpClient httpClient = new HttpClient();

        //        // Get Token
        //        httpClient.BaseAddress = new Uri("https://4-h.org/?oauth=token");
        //        List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
        //        postData.Add(new KeyValuePair<string, string>("client_id", "7f9NFx7MZ3TK8mknujsz6wcy0QVH5YBimEMd00Z2"));
        //        postData.Add(new KeyValuePair<string, string>("client_secret", "y5M87EGD5w8Ax507m3ynRbDlS09YB9TeJjDNJm8A"));
        //        postData.Add(new KeyValuePair<string, string>("scope", "basic"));
        //        postData.Add(new KeyValuePair<string, string>("token_type", "Bearer"));
        //        postData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

        //        HttpResponseMessage tokenResponse = httpClient.PostAsync(httpClient.BaseAddress, new FormUrlEncodedContent(postData)).Result;
        //        var result = tokenResponse.Content.ReadAsStringAsync().Result;
        //        var tokenResult = JsonConvert.DeserializeObject<dynamic>(result);
        //        var token = tokenResult.access_token.Value.ToString();
        //        if (null == token)
        //        {
        //            return StatusCode(400);
        //        }

        //        //// LGU
        //        //var extractURL = "https://4-h.org/wp-json/wp/v2/extension-lgu?per_page=100";
        //        //HttpResponseMessage extractResponse = httpClient.GetAsync(extractURL).Result;
        //        //var extract = extractResponse.Content.ReadAsStringAsync().Result;

        //        // Published Activity
        //        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token.ToString());
        //        var extractURL = "https://4-h.org/wp-json/wp/v2/activity-course";
        //        HttpResponseMessage extractResponse = httpClient.GetAsync(extractURL).Result;
        //        var extract = extractResponse.Content.ReadAsStringAsync().Result;

        //        // User
        //        //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token.ToString());
        //        //var extractURL = "https://4-h.org/wp-json/wp/v2/users?per_page=100";
        //        //HttpResponseMessage extractResponse = httpClient.GetAsync(extractURL).Result;
        //        //var extract = extractResponse.Content.ReadAsStringAsync().Result;

        //        ////Subsc
        //        //var client = new RestClient("https://4-h.org/wp-json/wc/v1/subscriptions");
        //        //var oAuth1 = OAuth1Authenticator.ForAccessToken(
        //        //                consumerKey: "ck_47a9e97def1643bb6c77f06e4674d970d1bfd3db",
        //        //                consumerSecret: "cs_94e19e51a1f7ddd39b0fbb9bf66cd493db356524",
        //        //                token: "",
        //        //                tokenSecret: "",
        //        //                OAuthSignatureMethod.HmacSha1);
        //        //oAuth1.Realm = Realm; // if Realm has otherwise ignore

        //        //client.Authenticator = oAuth1;

        //        //var request = new RestRequest("https://4-h.org/wp-json/wc/v1/subscriptions", Method.Post);
        //        //request.AddHeader("Content-Type", "application/json");
        //        //string body = JsonConvert.SerializeObject(bodyObject);

        //        //request.AddParameter("application/json", body, ParameterType.RequestBody);
        //        //var response = client.Execute(request);

        //        ////////////////////////////////*********************************************************

        //        //var client = new RestClient($"https://4-h.org/wp-json/wc/v1/subscriptions")
        //        //{
        //        //    Authenticator = OAuth1Authenticator.ForProtectedResource("ck_47a9e97def1643bb6c77f06e4674d970d1bfd3db",
        //        //    "cs_94e19e51a1f7ddd39b0fbb9bf66cd493db356524", null, null, OAuthSignatureMethod.HmacSha256)
        //        //};

        //        //var request = new RestRequest(Method.Get);
        //        //RestResponse response = client.Execute(request);
        //        //Console.WriteLine(response.Content);

        //        /// Posts
        //        //httpClient.BaseAddress = new Uri("https://4-h.org/wp-json/wp/v2/posts?");
        //        //var client2 = new WordPressClient("https://4-h.org/wp-json/");
        //        //var posts = await client2.Posts.GetAllAsync();
        //        //var postbyid = client2.Users.GetByIDAsync(25231).Result;
        //        //var postbyid = client2.Posts.GetByIDAsync(75381).Result;
        //        //var posts = postbyid.Content.Rendered;
        //        //var posts = postbyid.;
        //        //var httpClients = new HttpClient
        //        //{
        //        //    BaseAddress = new Uri(ApiCredentials.WordPressUri)
        //        //};
        //        //httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:33.0) Gecko/20100101 Firefox/33.0");
        //        //httpClient.DefaultRequestHeaders.Add("Referer", "https://github.com/wp-net/WordPressPCL");

        //        //var client = new WordPressClient(httpClient);
        //        //var posts = await client.Posts.GetAllAsync();

        //        //var client3 = new WordPressClient(c)
        //        return Ok(token);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok();
        //    }

        //    //var postbyid = await client.Posts.GetByIdAsync(id);
        //    //var postsCount = await client.Posts.GetCountAsync();

        //    //// User
        //    //var client = new WordPressClient("https://4-h.org/wp-json/wp/v2/users?per_page=100");
        //    //client.Auth.UseBearerAuth(JWTPlugin.JWTAuthByEnriqueChavez);
        //    //client.Auth.;
        //    //var comments = await client.Users.GetAllAsync();
        //    //var commentbyid = await client.Comments.GetByIdAsync(id);
        //    //var commentsbypost = await client.Comments.GetCommentsForPostAsync(postid, true, false);

        //    //// Authentication
        //    //var client = new WordPressClient(ApiCredentials.WordPressUri);

        //    ////Either Bearer Auth using JWT tokens
        //    //client.Auth.UseBearerAuth(JWTPlugin.JWTAuthByEnriqueChavez);
        //    //await client.Auth.RequestJWTokenAsync("username", "password");
        //    //var isValidToken = await client.IsValidJWTokenAsync();

        //    ////Or Basic Auth using Application Passwords
        //    //client.Auth.UseBasicAuth("username", "password");

        //    //// now you can send requests that require authentication
        //    //var response = client.Posts.DeleteAsync(postId);
        //    //return View();
        //}
    }
}
