namespace DatabasesApp.Models
{
	public class CashRegister
	{
		public int? Id { get; set; }
		public string? Code { get; set; }

		public override string ToString()
		{
			return $"Id: {Id} Code: {Code}";
		}
	}
}
