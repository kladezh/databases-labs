using System.Configuration;

namespace DatabasesApp.Application.Config.SqlQueries
{
	public class QueryElement : ConfigurationElement
	{
		[ConfigurationProperty("method", IsRequired = true)]
		public string Method => (string)base["method"];

		[ConfigurationProperty("text", IsRequired = true)]
		public string Text => (string)base["text"];
	}

}
