using DatabasesApp.Application.Attributes;
using System.Collections.Generic;

namespace DatabasesApp.Models
{
	public class Receipt
	{
		[Column("receipt_id")]
		public int Id { get; set; }

		[Column("worker_id")]
		public int WorkerId { get; set; }

		[Column("cashregister_id")]
		public int CashregisterId { get; set; }

		public Worker? Worker { get; set; }
		public Cashregister? Cashregister { get; set; }

		public List<Purchase>? Purchases { get; set; }
	}

}
