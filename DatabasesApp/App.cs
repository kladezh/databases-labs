﻿using System.Windows;

using DatabasesApp.Views;

namespace DatabasesApp
{
	public class App : System.Windows.Application
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
