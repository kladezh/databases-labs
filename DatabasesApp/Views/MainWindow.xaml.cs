using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using DatabasesApp.Interfaces;
using DatabasesApp.Models;

namespace DatabasesApp.Views
{
	public partial class MainWindow : Window
	{
		private readonly IDbContext _context;

		public MainWindow(IDbContext context)
		{
			_context = context;

			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var cashRegisters = _context.ExecuteQuery<CashRegister>("SELECT * FROM cashregister");

			var str = new StringBuilder();
			foreach(var cash in cashRegisters)
			{
				str.AppendLine(cash.ToString());
			}
			MessageBox.Show(str.ToString());
		}
	}
}

