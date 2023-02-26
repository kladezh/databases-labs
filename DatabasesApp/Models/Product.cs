using DatabasesApp.Application.Attributes;
using System.Collections.Generic;

namespace DatabasesApp.Models
{
	public class Product
	{
		[Column("product_id")]
		public int Id { get; set; }

		[Column("product_name")]
		public string Name { get; set; } = string.Empty;

		[Column("product_price")]
		public double Price { get; set; }

		[Column("product_amount")]
		public double Amount { get; set; }

		[Column("product_type_id")]
		public int TypeId { get; set; }

		[Column("product_unit_id")]
		public int UnitId { get; set; }

		public ProductType? Type { get; set; }
		public ProductUnit? Unit { get; set; }

		public List<Purchase>? Purchases { get; set; }
	}
}
