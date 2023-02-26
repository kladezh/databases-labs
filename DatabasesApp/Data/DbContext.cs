using DatabasesApp.Application.Config.SqlQueries;
using DatabasesApp.Application.Interfaces;
using DatabasesApp.Models;

namespace DatabasesApp.Data
{
	public class DbContext
	{
		private readonly IDbConnectionManager _connectionManager;
		private readonly SqlQueriesSection _queriesSection;

		public DbContext(IDbConnectionManager manager, SqlQueriesSection section)
		{
			_connectionManager = manager;
			_queriesSection = section;

			Initialize();
		}

		private void Initialize()
		{
			Cashregisters   = new DbRepository<Cashregister>  (_connectionManager, _queriesSection.TableQueries("cashregister"));
			Products        = new DbRepository<Product>       (_connectionManager, _queriesSection.TableQueries("product"));
			ProductTypes    = new DbRepository<ProductType>   (_connectionManager, _queriesSection.TableQueries("product_type"));
			ProductUnits    = new DbRepository<ProductUnit>   (_connectionManager, _queriesSection.TableQueries("product_unit"));
			Receipts        = new DbRepository<Receipt>       (_connectionManager, _queriesSection.TableQueries("receipt"));
			UserRights      = new DbRepository<UserRight>     (_connectionManager, _queriesSection.TableQueries("user_right"));
			WorkerPositions = new DbRepository<WorkerPosition>(_connectionManager, _queriesSection.TableQueries("worker_position"));
			Workers         = new DbRepository<Worker>        (_connectionManager, _queriesSection.TableQueries("worker"));
		}

		public IDbRepository<Cashregister> Cashregisters { get; set; }
		public IDbRepository<Product> Products { get; set; }
		public IDbRepository<ProductType> ProductTypes { get; set; }
		public IDbRepository<ProductUnit> ProductUnits { get; set; }
		public IDbRepository<Receipt> Receipts { get; set; }
		public IDbRepository<UserRight> UserRights { get; set; }
		public IDbRepository<WorkerPosition> WorkerPositions { get; set; }
		public IDbRepository<Worker> Workers { get; set; }
	}
}
