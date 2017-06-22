using System.Collections.Generic;
using Newtonsoft.Json;

namespace WifiParis.Domain.API
{
	public class Fields
	{
		public string Nom { get; set; }
        [JsonProperty("code_postal")]
		public string CodePostal { get; set; }
		public string Ville { get; set; }
        [JsonProperty ("numero_site_vdp")]
		public string NumeroSiteVdp { get; set; }
		public List<double> Xy { get; set; }
        [JsonProperty ("adresse_postale")]
		public string AdressePostale { get; set; }
	}
}
