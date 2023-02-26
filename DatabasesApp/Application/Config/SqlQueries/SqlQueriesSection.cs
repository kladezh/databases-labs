using System.Collections.Generic;
using System.Configuration;

namespace DatabasesApp.Application.Config.SqlQueries
{
	public class SqlQueriesSection : ConfigurationSection
	{
		[ConfigurationProperty("tables")]
		public TableCollection Tables => (TableCollection)base["tables"];

		public IDictionary<string, string> TableQueries(string name)
		{
			return Tables[name].Queries.ToDictionary();
		}
	}

}
