using System.Collections.Generic;

namespace WifiParis.Data
{
    public interface IUnitOfWork
    {
        void SaveWifiHotspots (IEnumerable<WifiHotspot> wifiHotspots);
        void DeleteAllWifiHotspots ();
        IEnumerable<WifiHotspot> GetAllWifiHotspots ();
    }
}
