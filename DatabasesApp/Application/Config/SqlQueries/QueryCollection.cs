using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DatabasesApp.Application.Config.SqlQueries
{
	[ConfigurationCollection(typeof(QueryElement), AddItemName = "query")]
	public class QueryCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new QueryElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((QueryElement)element).Method;
		}

		public QueryElement this[string method]
		{
			get { return (QueryElement)BaseGet(method); }
		}

		public IDictionary<string, string> ToDictionary() => 
			this.Cast<QueryElement>().ToDictionary(q => q.Method, q => q.Text);
	}

}
