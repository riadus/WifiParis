using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WifiParisComplete.Data;
using WifiParisComplete.Domain.API;
using WifiParisComplete.Domain.Attributes;
using WifiParisComplete.Domain.Interfaces;
using System;
using System.Diagnostics;

namespace WifiParisComplete.Domain.Services
{
    [RegisterInterfaceAsDynamic]
    public class BackendService : IBackendService
    {
        private IMapper<Record, WifiHotspot> WifiHotspotMapper { get; }
        private IApiClient ApiClient { get; }

        public BackendService (IApiClient apiClient, IMapper<Record, WifiHotspot> wifiHotspotMapper)
        {
            ApiClient = apiClient;
            WifiHotspotMapper = wifiHotspotMapper;
        }

        public async Task<IEnumerable<Record>> GetMoreRecords(int lastId)
        {
            var records = await ApiClient.GetAsync<List<Record>> ($"?dataset=liste-des-antennes-wifi&start={lastId}");
            return records;
        }

        public async Task<IEnumerable<WifiHotspot>> GetWifiHotspots(string postalCodeFilter)
        {
            await Task.Delay (1000).ConfigureAwait (false);
            var url = "?dataset=liste-des-antennes-wifi";
            if (!string.IsNullOrEmpty (postalCodeFilter))
            {
                url += $"&refine.code_postal={postalCodeFilter}";
            }
            try {
                var rootObject = await ApiClient.GetAsync<RootObject> (url);
                return rootObject.Records.Select (x => WifiHotspotMapper.Map (x)).ToList ();
            } catch (Exception e) {
                Debug.WriteLine($"error : {e.Message}");
                return new List<WifiHotspot> ();
            }
        }
    }
}
