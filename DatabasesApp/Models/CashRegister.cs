using DatabasesApp.Application.Attributes;
using System.Collections.Generic;

namespace DatabasesApp.Models
{
	public class Cashregister
	{
		[Column("cashregister_id")]
		public int Id { get; set; }

		[Column("cashregister_code")]
		public string Code { get; set; } = string.Empty;

		public List<Receipt>? Receipts { get; set; }
	}
}
