using System.Linq;
using WifiParisComplete.Data;
using WifiParisComplete.Domain.API;
using WifiParisComplete.Domain.Attributes;

namespace WifiParisComplete.Domain
{
    [RegisterInterfaceAsDynamic]
    public class WifiHotspotMapper : IMapper<Record, WifiHotspot>
    {
        IMapper<Fields, Address> AddressMapper { get; }
        public WifiHotspotMapper (IMapper<Fields, Address> addressMapper)
        {
            AddressMapper = addressMapper;
        }

        public WifiHotspot Map (Record source)
        {
            var address = AddressMapper.Map (source.Fields);
            var coordinates = new Coordinates ();
            if (source.Fields.Xy != null && source.Fields.Xy.Count() == 2)
            {
                coordinates.Latitude = source.Fields.Xy.ElementAt (0);
                coordinates.Longitude = source.Fields.Xy.ElementAt (1);
            }

            return new WifiHotspot {
                Address = address,
                Coordinates = coordinates,
                Name = source.Fields.Nom,
                SiteId = source.Fields.NumeroSiteVdp
            };
        }
    }
}
