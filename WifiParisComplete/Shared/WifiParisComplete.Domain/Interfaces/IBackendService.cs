using System.Collections.Generic;
using System.Threading.Tasks;
using WifiParisComplete.Data;
using WifiParisComplete.Domain.API;

namespace WifiParisComplete.Domain.Interfaces
{
    public interface IBackendService
    {
        Task<IEnumerable<WifiHotspot>> GetWifiHotspots(string postalCodeFilter);
		Task<IEnumerable<Record>> GetMoreRecords(int lastId);
    }
}
