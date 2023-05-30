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
                const string extension__lguQuery = @"INSERT INTO extension__lgu (Id, extension__lgu ) VALUES(@Id, @activity_course_grades, )";
                const string publishedActivityQuery = @"INSERT INTO publishedactivities (Id, date, modified, modified_gmt, slug,
                                       type, title, featured_media, template, course_or_activity, is_public_activity, location, partner,
                                       afri_category, course_about, course_sponsor_description, title_head) 
                                       VALUES(@Id, @date, @modified, @modified_gmt, @slug, @type, @title, @featured_media,
                                       @template, @course_or_activity, @is_public_activity, @location, @partner, @afri_category,
                                       @course_about, @course_sponsor_description, @title_head)";

                var rendered = "";
                var course_or_activity = "";
                var is_public_activity = "";
                var location = "";
                var partner = "";
                var afri_category = "";

                foreach (var key in publishedActivityModel.title)
                {
                    if ("rendered" == key.Key.ToString())
                    {
                        rendered = key.Value.ToString();
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

                #region Foreign key commented
                //const string publishedActivityQuery = @"INSERT INTO publishedactivities (Id, date, date_gmt, modified, modified_gmt, slug,
                //                       type, featured_media, template, topic, activity_type, activity_course_grades,
                //                       extension__lgu, course_or_activity, is_public_activity, location, partner,
                //                       afri_category, more_activities_category, course_activities, course_about, course_sponsor_description, title_head) 
                //                       VALUES(@Id, @date, date_gmt, @modified, @modified_gmt, @slug, @type, @featured_media,
                //                       @template, @topicForeign, @activity_typeForeign, @activity_course_gradesForeign,
                //                       @extension__lguForeign, @course_or_activity, @is_public_activity, @location, @partner,, @afri_category,
                //                       @more_activities_categoryForeign, @course_activitiesForeign, @course_about, @course_sponsor_description, @title_head)";

                //const string activityQuery = @"INSERT INTO activity_course_grades (Id, activity_course_grades) VALUES(@Id, @activity_course_grades, )";
                //const string activity_typeQuery = @"INSERT INTO activity_type (Id, activity_type) VALUES(@Id, @activity_course_grades, )";
                //const string course_activitiesQuery = @"INSERT INTO course_activities (Id, course_activities) VALUES(@Id, @activity_course_grades, )";
                //const string more_activities_categoryQuery = @"INSERT INTO more_activities_category (Id, more_activities_category) VALUES(@Id, @activity_course_grades, )";
                //const string topicQuery = @"INSERT INTO topic (Id, topic) VALUES(@Id, @activity_course_grades)";

                //List<string> activity_course_grades = new List<string>();
                //foreach (var key in publishedActivityModel.acf)
                //{
                //    if("activity_course_grades" == key.Key.ToString())
                //    {
                //        foreach(var value in key.Value)
                //        {
                //            activity_course_grades.Add(value.ToString());
                //        }
                //        activity_course_grades.Add(ite);
                //        //activity_course_grades =;
                //    }
                //}

                //await _dbConnection.ExecuteAsync(activityQuery, new
                //{
                //    //activityQuery = publishedActivityModel.activityQuery
                //});

                //await _dbConnection.ExecuteAsync(activity_typeQuery, new
                //{
                //    Id = publishedActivityModel.Id
                //});

                //await _dbConnection.ExecuteAsync(course_activitiesQuery, new
                //{
                //    Id = publishedActivityModel.Id
                //});

                //await _dbConnection.ExecuteAsync(more_activities_categoryQuery, new
                //{
                //    Id = publishedActivityModel.Id
                //});

                //await _dbConnection.ExecuteAsync(topicQuery, new
                //{
                //    Id = publishedActivityModel.Id
                //});
                #endregion

                _connectionFactory.OpenConnection();
                //await _dbConnection.ExecuteAsync(extension__lguQuery, new
                //{
                //    Id = publishedActivityModel.Id
                //});
                
                await _dbConnection.ExecuteAsync(publishedActivityQuery, new
                {
                    Id = publishedActivityModel.Id,
                    date = publishedActivityModel.date,
                    modified = publishedActivityModel.modified,
                    modified_gmt = publishedActivityModel.modified_gmt,
                    slug = publishedActivityModel.slug,
                    type = publishedActivityModel.type,
                    title = rendered,
                    featured_media = publishedActivityModel.featured_media,
                    course_or_activity = course_or_activity,
                    is_public_activity = is_public_activity,
                    location = location,
                    partner = partner,
                    afri_category = afri_category,  
                    course_about = publishedActivityModel.course_about,
                    course_sponsor_description = publishedActivityModel.course_sponsor_description,
                    title_head = publishedActivityModel.title_head,
                    template = publishedActivityModel.template

                    //date_gmt = publishedActivityModel.date_gmt,
                    //topicForeign = publishedActivityModel.topicForeign,
                    //activity_typeForeign = publishedActivityModel.activity_typeForeign,
                    //activity_course_gradesForeign = publishedActivityModel.activity_course_gradesForeign,
                    //extension__lguForeign = publishedActivityModel.extension__lguForeign,
                    //more_activities_categoryForeign = publishedActivityModel.more_activities_categoryForeign,  
                    //course_activitiesForeign = publishedActivityModel.course_activitiesForeign,
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
                const string query = @"INSERT INTO LguExtention (Id, status , Date) VALUES(@Id, @Status, @Date)";

                _connectionFactory.OpenConnection();
                await _dbConnection.ExecuteAsync(query, new
                {
                    Id = lguExtention.Id,
                    Status = lguExtention.Status,
                    Date = lguExtention.Date
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
        public async Task AddUsersAsync(UsersModel Users)
        {
            try
            {
                const string userQuery = @"INSERT INTO user (Id, Username, Name, First_name, Last_name, Email, Description, Link, 
                                     Nickname, Slug, Registered_date, Is_super_admin) VALUES(@Id, @Username, @Name, @First_name, 
                                     @Last_name, @Email, @Description, @Link, @Nickname, @Slug, @Registered_date, @Is_super_admin)";
                 
                const string rolesQuery = @"INSERT INTO Roles (Id, roles) VALUES(@Id, @Role)";
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

