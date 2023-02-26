using System.Configuration;

namespace DatabasesApp.Application.Config.SqlQueries
{
	public class TableElement : ConfigurationElement
	{
		[ConfigurationProperty("name", IsRequired = true)]
		public string Name => (string)base["name"];

		[ConfigurationProperty("queries")]
		public QueryCollection Queries => (QueryCollection)base["queries"];
	}

}
