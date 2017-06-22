using System.Collections.Generic;

namespace WifiParis.Domain.API
{
	public class FacetGroup
	{
		public string Name { get; set; }
		public List<Facet> Facets { get; set; }
	}
}
