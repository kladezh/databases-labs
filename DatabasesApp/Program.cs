using System;
using System.Configuration;
using System.Data.Common;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MySqlConnector;

using DatabasesApp.Models;
using DatabasesApp.Views;
using DatabasesApp.Application.Interfaces;
using DatabasesApp.Application.Config.SqlQueries;
using DatabasesApp.Data;
using DatabasesApp.Data.Mapping;


namespace DatabasesApp
{
    public class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			var app = host.Services.GetService<App>();

			app!.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
			.ConfigureServices(services =>
			{
				services.AddSingleton<App>();
				services.AddSingleton<MainWindow>();

				TypeMapper.Initialize("DatabasesApp.Models");

				// DbConnectionManager
				var conn = ConfigurationManager.ConnectionStrings["MySQL"];
				DbProviderFactories.RegisterFactory(conn.ProviderName, MySqlConnectorFactory.Instance);

				var dbConnectionManager = new DbConnectionManager(
					DbProviderFactories.GetFactory(conn.ProviderName), conn.ConnectionString);

				services.AddSingleton<IDbConnectionManager>(dbConnectionManager);

				// DbContext
				var section = (SqlQueriesSection)ConfigurationManager.GetSection("sqlQueries");

				services.AddSingleton(sp => new DbContext
				{
					Cashregisters   = new DbRepository<Cashregister>  (dbConnectionManager, section.TableQueries("cashregister")),
					Products        = new DbRepository<Product>       (dbConnectionManager, section.TableQueries("product")),
					ProductTypes    = new DbRepository<ProductType>   (dbConnectionManager, section.TableQueries("product_type")),
					ProductUnits    = new DbRepository<ProductUnit>   (dbConnectionManager, section.TableQueries("product_unit")),
					Receipts        = new DbRepository<Receipt>       (dbConnectionManager, section.TableQueries("receipt")),
					UserRights      = new DbRepository<UserRight>     (dbConnectionManager, section.TableQueries("user_right")),
					WorkerPositions = new DbRepository<WorkerPosition>(dbConnectionManager, section.TableQueries("worker_position")),
					Workers         = new DbRepository<Worker>        (dbConnectionManager, section.TableQueries("worker")),
				});
			});
	}
}
