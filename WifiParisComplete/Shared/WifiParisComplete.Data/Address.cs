using System;
namespace WifiParisComplete.Data
{
    public class Address : SavableData
    {
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
