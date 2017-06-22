using Newtonsoft.Json;

namespace WifiParis.Domain.API
{
	public class Record
	{
		public string Datasetid { get; set; }
		public string Recordid { get; set; }
		public Fields Fields { get; set; }
		public Geometry Geometry { get; set; }
        [JsonProperty("record_timestamp")]
		public string RecordTimestamp { get; set; }
	}
}
