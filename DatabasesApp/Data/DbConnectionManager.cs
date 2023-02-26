using System;
using System.Data;
using System.Data.Common;

using DatabasesApp.Application.Interfaces;

namespace DatabasesApp.Data
{
    public class DbConnectionManager : IDbConnectionManager
	{
        private readonly DbProviderFactory _providerFactory;
        private readonly string _connectionString;

        public DbConnectionManager(DbProviderFactory providerFactory, string connectionString)
        {
            _providerFactory = providerFactory;
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            var conn = _providerFactory.CreateConnection();

            if (conn is null) throw new Exception("DbConnection is null");

            conn.ConnectionString = _connectionString;

            return conn;
        }
    }
}
