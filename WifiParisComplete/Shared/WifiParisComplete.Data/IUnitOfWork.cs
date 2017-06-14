using System.Collections.Generic;

namespace WifiParisComplete.Data
{
    public interface IUnitOfWork
    {
        void SaveWifiHotspots (IEnumerable<WifiHotspot> wifiHotspots);
        void DeleteAllWifiHotspots ();
        IEnumerable<WifiHotspot> GetAllWifiHotspots ();
    }
}
