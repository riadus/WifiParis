using System;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace WifiParisComplete.Data
{
    public class Address : SavableData
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [ForeignKey (typeof (WifiHotspot))]
        public int? WifiHotspotId { get; set; }

        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
