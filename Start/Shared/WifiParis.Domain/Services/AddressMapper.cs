using WifiParis.Data;
using WifiParis.Domain.API;
using WifiParis.Domain.Attributes;
using WifiParis.Domain.Interfaces;

namespace WifiParis.Domain
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
