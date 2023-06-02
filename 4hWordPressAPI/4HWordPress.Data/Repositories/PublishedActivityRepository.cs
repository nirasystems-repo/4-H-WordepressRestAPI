using _4HWordPress.Core.Domain;
using _4HWordPress.Core.Infrastructure;
using _4HWordPress.Core.IRepositories;
using Microsoft.Extensions.Logging;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4HWordPress.Data.Repositories
{
    public class PublishedActivityRepository : IPublishedActivityRepository
    {
        /// <summary>
        /// The connection factory
        /// </summary>
        private readonly IConnectionFactory _connectionFactory;

        /// <summary>
        /// The database connection
        /// </summary>
        private readonly IDbConnection _dbConnection;

        /// <summary>
        /// The transaction connection
        /// </summary>
        private IDbTransaction _transaction;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PublishedActivityRepository"/> class.
        /// </summary>
        /// <param name="connectionFactory">The connection factory.</param>
        //public PublishedActivityRepository(IConnectionFactory connectionFactory, ILogger logger)
        public PublishedActivityRepository(IConnectionFactory connectionFactory, ILogger<PublishedActivityRepository> logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
            _dbConnection = connectionFactory.GetConnection();
        }

        #region Get
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<List<PublishedActivityModel>> GetAsync()
        {
            List<PublishedActivityModel> publishedActivityModels = new List<PublishedActivityModel>();
            try
            {
                //const string query = @"SELECT * FROM publishedactivities";
                //_connectionFactory.OpenConnection();
                //var result = await _dbConnection.QueryAsync<PublishedActivityModel>(query);
                return publishedActivityModels;


            }
            catch (Exception e)
            {
                //_logger.LogError(e.ToString());
                return publishedActivityModels;
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }
        }
        #endregion

        #region Add Published Activity
        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="publishedActivityModel">The publishedActivityModel.</param>
        public async Task AddPublishedActivityAsync(PublishedActivityModel publishedActivityModel)
        {
            try
            {
                const string publishedActivityQuery = @"INSERT INTO publishedactivities (ID, Date, Modified, ModifiedGmt, Slug, Status,
                                       Type, Title, FeaturedMedia, Template, CourseOrActivity, IsPublicActivity, Location, Partner,
                                       AfriCategory, TitleHead) 
                                       VALUES(@Id, @date, @modified, @modified_gmt, @slug, @status, @type, @title, @featured_media,
                                       @template, @course_or_activity, @is_public_activity, @location, @partner, @afri_category, @title_head)";

                var rendered = "";
                var course_or_activity = "";
                var is_public_activity = "";
                var location = "";
                var partner = "";
                var afri_category = "";
                var title_head = "";

                foreach (var key in publishedActivityModel.title)
                {
                    if ("rendered" == key.Key.ToString())
                    {
                        rendered = key.Value.ToString();
                    }
                }
                foreach (var key1 in publishedActivityModel.yoast_head_json)
                {
                    if ("title" == key1.Key.ToString())
                    {
                        title_head = key1.Value.ToString();
                    }
                }
                foreach (var key in publishedActivityModel.acf)
                {
                    if("course_or_activity" == key.Key.ToString())
                    {
                        course_or_activity = key.Value.ToString();
                    }
                    if ("is_public_activity" == key.Key.ToString())
                    {
                        is_public_activity = key.Value.ToString();
                    }
                    if ("location" == key.Key.ToString())
                    {
                        location = key.Value.ToString();
                    }
                    if ("partner" == key.Key.ToString())
                    {
                        partner = key.Value.ToString();
                    }
                    if ("afri_category" == key.Key.ToString())
                    {
                        afri_category = key.Value.ToString();
                    }
                }

                _connectionFactory.OpenConnection();
                await _dbConnection.ExecuteAsync(publishedActivityQuery, new
                {
                    Id = publishedActivityModel.Id,
                    date = publishedActivityModel.date,
                    modified = publishedActivityModel.modified,
                    modified_gmt = publishedActivityModel.modified_gmt,
                    slug = publishedActivityModel.slug,
                    status = publishedActivityModel.status,
                    type = publishedActivityModel.type,
                    title = rendered,
                    featured_media = publishedActivityModel.featured_media,
                    course_or_activity = course_or_activity,
                    is_public_activity = is_public_activity,
                    location = location,
                    partner = partner,
                    afri_category = afri_category,  
                    title_head = title_head,
                    template = publishedActivityModel.template
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }
        }
        #endregion
        
        #region Add LGU Extention
        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="publishedActivityModel">The publishedActivityModel.</param>
        public async Task AddLguExtentionAsync(LguExtentionModel lguExtention)
        {
            try
            {
                const string query = @"INSERT INTO extensionlgu (ID, Status, Date, DateGmt, Modified, ModifiedGmt, Slug, 
                                     Type, Title, TitleHead) VALUES(@Id, @Status, @Date, @Date_gmt, @Modified, @Modified_gmt, 
                                     @Slug, @Type, @Title, @Title_Head)";

                var rendered = "";
                var title_head = "";
                foreach (var key in lguExtention.title)
                {
                    if ("rendered" == key.Key.ToString())
                    {
                        rendered = key.Value;
                    }
                }
                foreach (var key1 in lguExtention.yoast_head_json)
                {
                    if ("title" == key1.Key.ToString())
                    {
                        title_head = key1.Value.ToString();
                    }
                }
                _connectionFactory.OpenConnection();
                await _dbConnection.ExecuteAsync(query, new
                {
                    Id = lguExtention.Id,
                    Status = lguExtention.Status,
                    Date = lguExtention.Date,
                    Date_gmt = lguExtention.Date_gmt,
                    Modified = lguExtention.Modified,
                    Modified_gmt = lguExtention.Modified_gmt,
                    Slug = lguExtention.Slug,
                    Type = lguExtention.Type,
                    Title = rendered,
                    Title_Head = title_head
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }
        }
        #endregion
        
        #region Add User
        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="publishedActivityModel">The publishedActivityModel.</param>
        public async Task AddUsersAsync(UsersModel Users)
        {
            try
            {
                const string userQuery = @"INSERT INTO user (ID, Username, Name, FirstName, LastName, Email, Description, Link, 
                                     Nickname, Slug, RegisteredDate, IsSuperAdmin) VALUES(@Id, @Username, @Name, @First_name, 
                                     @Last_name, @Email, @Description, @Link, @Nickname, @Slug, @Registered_date, @Is_super_admin)";
                 
                const string rolesQuery = @"INSERT INTO Roles (ID, Roles) VALUES(@Id, @Role)";
                _connectionFactory.OpenConnection();
                await _dbConnection.ExecuteAsync(userQuery, new
                {
                    Id = Users.Id,
                    Username = Users.Username,
                    Name = Users.Name,
                    First_name = Users.First_name,
                    Last_name = Users.Last_name,
                    Email = Users.Email,
                    Description = Users.Description,
                    Link = Users.Link,
                    Nickname = Users.Nickname,
                    Slug = Users.Slug,
                    //roles
                    Registered_date = Users.Registered_date,
                    Is_super_admin = Users.Is_super_admin

                });

                foreach(string role in Users.Roles)
                {
                    await _dbConnection.ExecuteAsync(rolesQuery, new
                    {
                        Id = Users.Id,
                        Role = role
                    });
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }
        }
        #endregion
    }
}

