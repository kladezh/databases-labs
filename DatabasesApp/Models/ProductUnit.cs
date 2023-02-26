using DatabasesApp.Application.Attributes;
using System.Collections.Generic;

namespace DatabasesApp.Models
{
	public class ProductUnit
	{
		[Column("product_unit_id")]
		public int Id { get; set; }

		[Column("product_unit_name")]
		public string Name { get; set; } = string.Empty; // enum

		public List<Product>? Products { get; set; } = null;
	}

}
