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
                PostalCode = source.CodePostal,
                Street = source.AdressePostale
            };
        }
    }
}
