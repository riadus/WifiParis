using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace WifiParisComplete.Data
{
    public class Coordinates : SavableData
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [ForeignKey (typeof (WifiHotspot))]
        public int? WifiHotspotId { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
