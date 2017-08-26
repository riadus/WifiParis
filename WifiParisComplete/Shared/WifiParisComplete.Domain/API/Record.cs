using System;
using Newtonsoft.Json;

namespace WifiParisComplete.Domain.API
{
	public class Record
	{
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("datasetid")]
		public string Datasetid { get; set; }
		[JsonProperty("recordid")]
		public string Recordid { get; set; }
		[JsonProperty("fields")]
		public Fields Fields { get; set; }
		[JsonProperty("geometry")]
		public Geometry Geometry { get; set; }
        [JsonProperty("record_timestamp")]
		public string RecordTimestamp { get; set; }
	}
}
