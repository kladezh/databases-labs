using System.Configuration;

namespace DatabasesApp.Application.Config.SqlQueries
{
	[ConfigurationCollection(typeof(TableCollection), AddItemName = "table")]
	public class TableCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new TableElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((TableElement)element).Name;
		}

		public TableElement this[string name]
		{
			get { return (TableElement)BaseGet(name); }
		}
	}

}
