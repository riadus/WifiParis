using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WifiParisComplete.Domain.API
{
	public class Fields
	{
		public string Nom { get; set; }
        [JsonProperty("code_postal")]
		public int CodePostal { get; set; }
		public string Ville { get; set; }
        [JsonProperty ("numero_site_vdp")]
		public string NumeroSiteVdp { get; set; }
		public List<double> Xy { get; set; }
        [JsonProperty ("adresse_postale")]
		public string AdressePostale { get; set; }
	}
}
