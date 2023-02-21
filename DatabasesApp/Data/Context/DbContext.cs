using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Dapper;

using DatabasesApp.Interfaces;

namespace DatabasesApp.Data.Context
{
	public class DbContext : IDbContext
	{
		private readonly DbProviderFactory _providerFactory;
		private readonly string _connectionString;

		public DbContext(DbProviderFactory providerFactory, string connectionString)
		{
			_providerFactory = providerFactory;
			_connectionString = connectionString;
		}

		public IEnumerable<T> ExecuteQuery<T>(string sql, object? param = null, CommandType? type = null)
		{
			using var conn = _providerFactory.CreateConnection();

			if (conn is null) throw new Exception("DbConnection is null");

			conn.ConnectionString = _connectionString;
			conn.Open();

			return conn.Query<T>(sql: sql, param: param, commandType: type);

		}
		public object ExecuteQueryScalar(string sql, object? param = null, CommandType? type = null)
		{
			using var conn = _providerFactory.CreateConnection();

			if (conn is null) throw new Exception("DbConnection is null");

			conn.ConnectionString = _connectionString;
			conn.Open();

			return conn.ExecuteScalar(sql: sql, param: param, commandType: type);
		}

		public int ExecuteNonQuery(string sql, object? param = null, CommandType? type = null)
		{
			using var conn = _providerFactory.CreateConnection();

			if (conn is null) throw new Exception("DbConnection is null");

			conn.ConnectionString = _connectionString;
			conn.Open();

			return conn.Execute(sql: sql, param: param, commandType: type);
		}
	}
}
