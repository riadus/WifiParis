using System;
using System.Collections.Generic;
using WifiParisComplete.Data;

namespace WifiParisComplete.Services
{
    public interface INavigationService
    {
        void ShowHomePage ();
        void ShowWifiPage ();
        void ShowMap (IEnumerable<WifiHotspot> hotspots);
    }
}
