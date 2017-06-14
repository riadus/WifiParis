using System;
using System.Collections.Generic;

namespace WifiParisComplete.Domain.API
{
	public class FacetGroup
	{
		public string Name { get; set; }
		public List<Facet> Facets { get; set; }
	}
}
