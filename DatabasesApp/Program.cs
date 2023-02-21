using System;
using System.Configuration;
using System.Data.Common;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MySqlConnector;

using DatabasesApp.Views;
using DatabasesApp.Interfaces;
using DatabasesApp.Data.Context;

namespace DatabasesApp
{
	public class Program
	{
		[STAThread]
		public static void Main()
		{
			var host = Host.CreateDefaultBuilder()
			.ConfigureServices(services =>
			{
				services.AddSingleton<App>();
				services.AddSingleton<MainWindow>();

				// DbContext
				var conn = ConfigurationManager.ConnectionStrings["MySQLConnection"];
				DbProviderFactories.RegisterFactory(conn.ProviderName, MySqlConnectorFactory.Instance);

				services.AddSingleton<IDbContext>(new DbContext (
					DbProviderFactories.GetFactory(conn.ProviderName), conn.ConnectionString));
			})
			.Build();

			var app = host.Services.GetService<App>();

			app!.Run();
		}
	}
}
