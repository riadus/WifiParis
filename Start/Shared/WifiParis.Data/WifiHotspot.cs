namespace WifiParis.Data
{
	public class WifiHotspot 
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public Address Address { get; set; }

		public string SiteId { get; set; }

		public Coordinates Coordinates { get; set; }
	}
}