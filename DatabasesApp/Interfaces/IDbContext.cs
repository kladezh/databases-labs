using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasesApp.Interfaces
{
	public interface IDbContext
	{
		public IEnumerable<T> ExecuteQuery<T>(string sql, object? param = null, CommandType? type = null);
		public object ExecuteQueryScalar(string sql, object? param = null, CommandType? type = null);
		public int ExecuteNonQuery(string sql, object? param = null, CommandType? type = null);
	}
}
