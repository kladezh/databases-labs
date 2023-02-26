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
using DatabasesApp.Application.Mapping;
using DatabasesApp.Data;
using DatabasesApp.Data.Mapping;
using DatabasesApp.Services;


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

				services.AddSingleton<IDbConnectionManager>(new DbConnectionManager(
					DbProviderFactories.GetFactory(conn.ProviderName), conn.ConnectionString));

				// DbContext
				var section = (SqlQueriesSection)ConfigurationManager.GetSection("sqlQueries");

				services.AddSingleton(sp => new DbContext(
					sp.GetRequiredService<IDbConnectionManager>(), section));
			});
	}
}
