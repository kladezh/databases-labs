using DatabasesApp.Application.Attributes;
using System.Collections.Generic;

namespace DatabasesApp.Models
{
	public class UserRight
	{
		[Column("user_right_id")]
		public int Id { get; set; }

		[Column("user_right_name")]
		public string Name { get; set; } = string.Empty; // enum

		public List<Worker>? Workers { get; set; } = null;
	}

}
