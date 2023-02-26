using DatabasesApp.Application.Attributes;
using System.Collections.Generic;

namespace DatabasesApp.Models
{
	public class Worker
	{
		[Column("worker_id")]
		public int Id { get; set; }

		[Column("worker_name")]
		public string Name { get; set; } = string.Empty;

		[Column("worker_email")]
		public string Email { get; set; } = string.Empty;

		[Column("worker_password")]
		public string Password { get; set; } = string.Empty;

		[Column("worker_position_id")]
		public int PositionId { get; set; }

		[Column("user_right_id")]
		public int RightId { get; set; }

		public WorkerPosition? Position { get; set; }
		public UserRight? Right { get; set; }

		public List<Receipt>? Receipts { get; set; }
	}

}
