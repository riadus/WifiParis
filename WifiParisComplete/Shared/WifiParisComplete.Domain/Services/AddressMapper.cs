using System;
using WifiParisComplete.Data;
using WifiParisComplete.Domain.API;
using WifiParisComplete.Domain.Attributes;

namespace WifiParisComplete.Domain
{
    [RegisterInterfaceAsDynamic]
    public class AddressMapper : IMapper<Fields, Address>
    {
        public Address Map (Fields source)
        {
            return new Address {
                City = source.Ville,
                PostalCode = source.CodePostal.ToString(),
                Street = source.AdressePostale
            };
        }

        public Fields MapBack(Address source)
        {
            return new Fields
            {
                Ville = source.City,
                CodePostal = Int32.Parse(source.PostalCode),
                AdressePostale = source.Street
            };
        }
    }
}
