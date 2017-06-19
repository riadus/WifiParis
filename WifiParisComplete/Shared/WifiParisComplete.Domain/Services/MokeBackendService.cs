using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WifiParisComplete.Data;
using WifiParisComplete.Domain.API;
using WifiParisComplete.Domain.Attributes;
using WifiParisComplete.Domain.Interfaces;

namespace WifiParisComplete.Domain
{
    public class MokeBackendService : IBackendService
    {
        public Task<IEnumerable<Record>> GetMoreRecords (int lastId)
        {
            throw new NotImplementedException ();
        }

        public async Task<IEnumerable<WifiHotspot>> GetWifiHotspots (string postalCodeFilter)
        {
            await Task.Delay (1000).ConfigureAwait (false);
            var list = new List<WifiHotspot> ();
            var address = new Address {
                City = "Paris",
                PostalCode = "75011",
                Street = "Rue de la fontaine au roi",
                WifiHotspotId = 12
            };
            var coordinates = new Coordinates {
                WifiHotspotId = 12,
                Latitude = 12,
                Longitude = 12
            };

            for (int i = 1; i <= 10; i++) {
                var wifiHotspot = new WifiHotspot {
                    Address = address,
                    Coordinates = coordinates,
                    Name = $"Borne {i}",
                    SiteId = $"Site {i}"
                };
                list.Add (wifiHotspot);
            }
            return list;
        }
    }
}
