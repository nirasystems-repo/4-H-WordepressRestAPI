using _4HWordPress.Core.Infrastructure;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4HWordPress.Api.Infrastructure
{
    public class ConnectionFactory : IConnectionFactory
    {
        private IDbConnection conn = null;
        /// <summary>
        /// For live db connection
        /// </summary>
        /// <param name="configurationManager"></param>
        public ConnectionFactory(IConfigurationManager configurationManager)
        {
            //DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
            //var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            DbProviderFactories.RegisterFactory("MySql.Data.MySqlClient", MySqlClientFactory.Instance);
            var factory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
            conn = factory.CreateConnection();
            conn.ConnectionString = configurationManager.ConnectionString;
        }

        /// <summary>
        /// For testing,
        /// this constructor is for injecting test db connection string
        /// </summary>
        /// <param name="connectionString">Test db connection string</param>
        public ConnectionFactory(string connectionString)
        {
            //DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
            //var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            DbProviderFactories.RegisterFactory("MySql.Data.MySqlClient", MySqlClientFactory.Instance);
            var factory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
            conn = factory.CreateConnection();
            conn.ConnectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return conn;
        }

        public void OpenConnection()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }

        public void CloseConnection()
        {
            if (conn != null && conn.State != ConnectionState.Closed)
                conn.Close();
        }

        public IDbTransaction BeginTransaction(IDbConnection dbConnection)
        {
            return dbConnection.BeginTransaction();
        }

        public void Commit(IDbTransaction dbTransaction)
        {
            dbTransaction.Commit();
        }

        public void Rollback(IDbTransaction dbTransaction)
        {
            dbTransaction.Rollback();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ConnectionFactory() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
