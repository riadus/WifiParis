using System.Collections.Generic;
using Newtonsoft.Json;

namespace WifiParis.Domain.API
{
	public class RootObject
	{
		public int Nhits { get; set; }
		public Parameters Parameters { get; set; }
		public List<Record> Records { get; set; }
        [JsonProperty("facet_groups")]
		public List<FacetGroup> FacetGroups { get; set; }
	}
}
