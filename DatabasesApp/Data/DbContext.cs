using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DatabasesApp.Application.Interfaces;
using DatabasesApp.Models;

namespace DatabasesApp.Data
{
	public class DbContext
	{
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
