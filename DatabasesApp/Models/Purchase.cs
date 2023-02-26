using DatabasesApp.Application.Attributes;

namespace DatabasesApp.Models
{
	public class Purchase
	{
		[Column("purchase_count")]
		public double Count { get; set; }

		[Column("purchase_cost")]
		public double Cost { get; set; }

		[Column("receipt_id")]
		public int ReceiptId { get; set; }

		[Column("product_id")]
		public int ProductId { get; set; }

		public Receipt? Receipt { get; set; }
		public Product? Product { get; set; }
	}




}
