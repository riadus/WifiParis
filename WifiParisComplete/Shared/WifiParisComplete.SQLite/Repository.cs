using System;
using System.Collections.Generic;
using WifiParisComplete.Data;

namespace WifiParisComplete.Sqlite
{
	public class Repository<T> : IRepository<T> where T : new()
	{
		List<T> InMemoryData { get; set; }
		public Repository ()
		{
			InMemoryData = new List<T> ();
		}
		public int DeleteAll ()
		{
			InMemoryData = new List<T> ();
			return 1;
		}

		public IEnumerable<T> GetAll ()
		{
			return InMemoryData;
		}

		public void Save (IEnumerable<T> items)
		{
			InMemoryData.InsertRange (InMemoryData.Count, items);
		}
	}
}