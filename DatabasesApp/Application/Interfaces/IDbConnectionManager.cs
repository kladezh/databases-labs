using System.Data;

namespace DatabasesApp.Application.Interfaces
{
    public interface IDbConnectionManager
    {
		public IDbConnection GetConnection();
	}
}
