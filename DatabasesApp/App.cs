using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using DatabasesApp.Views;

namespace DatabasesApp
{
	public class App : Application
	{
		private readonly MainWindow _mainWindow;

		public App(MainWindow mainWindow)
		{
			_mainWindow = mainWindow;
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			_mainWindow.Show();
			base.OnStartup(e);
		}
	}
}
