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
        private int _lastId;
        public BackendService (IApiClient apiClient, IMapper<Record, WifiHotspot> wifiHotspotMapper)
        {
            ApiClient = apiClient;
            WifiHotspotMapper = wifiHotspotMapper;
        }

        public async Task<IEnumerable<WifiHotspot>> GetMoreWifiHotspots (string postalCodeFilter)
        {
            //await Task.Delay (1000).ConfigureAwait (false);
            var url = $"{GetUrl (postalCodeFilter)}&start={_lastId}";
            var list = await GetData (url);
            _lastId += list.Count ();
            return list;
        }

        public async Task<IEnumerable<WifiHotspot>> GetWifiHotspots(string postalCodeFilter)
        {
            //await Task.Delay (1000).ConfigureAwait (false);
            var url = GetUrl (postalCodeFilter);
            var list = await GetData (url);
            _lastId = list.Count ();
            return list;
        }

        private string GetUrl (string postalCodeFilter)
        {
            var url = "?dataset=liste-des-antennes-wifi";
            if (!string.IsNullOrEmpty (postalCodeFilter)) {
                url += $"&fields.code_postal={postalCodeFilter}";
            }
            return url;
        }

        private async Task<IEnumerable<WifiHotspot>> GetData (string url)
        {
            try {
                if (ApiClient.IsLocal)
                {
                    var rootObject = await ApiClient.GetAsync<List<Record>>(url);
                    var list = rootObject.Select(x => WifiHotspotMapper.Map(x)).ToList();
                    return list;
                }
                else
                {
                    var rootObject = await ApiClient.GetAsync<RootObject>(url);
                    var list = rootObject.Records.Select(x => WifiHotspotMapper.Map(x)).ToList();
                    return list;
                }
            } catch (Exception e) {
                Debug.WriteLine ($"error : {e.Message}");
                return new List<WifiHotspot> ();
            }
        }

        public async Task AddWifiHotspot(WifiHotspot wifiHotspot)
        {
            try{
                if(ApiClient.IsLocal)
                {
                    var record = WifiHotspotMapper.MapBack(wifiHotspot);
                    var response = await ApiClient.PostAsync<object, Record>("", record);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"error : {e.Message}");
            }
        }
    }
}
