using System.Collections.Generic;
using System.Threading.Tasks;
using WifiParisComplete.Data;

namespace WifiParisComplete.Domain.Interfaces
{
    public interface IBackendService
    {
        Task<IEnumerable<WifiHotspot>> GetWifiHotspots(string postalCodeFilter);
        Task<IEnumerable<WifiHotspot>> GetMoreWifiHotspots(string postalCodeFilter);
        Task AddWifiHotspot(WifiHotspot wifiHotspot);
    }
}
