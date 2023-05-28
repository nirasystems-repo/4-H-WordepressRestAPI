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
        public PublishedActivityRepository(IConnectionFactory connectionFactory, ILogger logger)
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
                const string query = @"SELECT * FROM publishedactivities";
                _connectionFactory.OpenConnection();
                var result = await _dbConnection.QueryAsync<PublishedActivityModel>(query);
                return publishedActivityModels = result?.AsList();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return publishedActivityModels;
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }
        }
        #endregion
    }
}

