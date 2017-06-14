using System.Collections.Generic;
using System.Threading.Tasks;
using WifiParisComplete.Data;
using WifiParisComplete.Domain.API;

namespace WifiParisComplete.Domain.Interfaces
{
    public interface IBackendService
    {
		Task<List<WifiHotspot>> GetWifiHotspots(string postalCodeFilter);
		Task<List<Record>> GetMoreRecords(int lastId);
    }
}
