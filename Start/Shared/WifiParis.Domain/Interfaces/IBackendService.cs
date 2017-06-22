using System.Collections.Generic;
using System.Threading.Tasks;
using WifiParis.Data;

namespace WifiParis.Domain.Interfaces
{
	public interface IBackendService
	{
		Task<IEnumerable<WifiHotspot>> GetWifiHotspots(string postalCodeFilter);
		Task<IEnumerable<WifiHotspot>> GetMoreWifiHotspots(string postalCodeFilter);
	}
}
