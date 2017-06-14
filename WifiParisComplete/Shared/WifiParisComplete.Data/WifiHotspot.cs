using SQLiteNetExtensions.Attributes;

namespace WifiParisComplete.Data
{
    public class WifiHotspot : SavableData
    {
        public string Name { get; set; }

        [ForeignKey (typeof (Address))]
        public int? AddressId { get; set; }

        [OneToOne (nameof (AddressId))]
        public Address Address { get; set; }

        public string SiteId { get; set; }

        [ForeignKey (typeof (Coordinates))]
        public int? CoordinatesId { get; set; }

        [OneToOne (nameof (CoordinatesId))]
        public Coordinates Coordinates { get; set; }
    }
}
