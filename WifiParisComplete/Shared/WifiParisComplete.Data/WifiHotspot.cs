using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace WifiParisComplete.Data
{
    public class WifiHotspot : SavableData
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        [OneToOne]
        public Address Address { get; set; }

        public string SiteId { get; set; }

        [OneToOne]
        public Coordinates Coordinates { get; set; }
    }
}
