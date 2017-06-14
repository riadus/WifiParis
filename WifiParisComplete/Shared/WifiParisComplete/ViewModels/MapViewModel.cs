using System;
using System.Collections.Generic;
using WifiParisComplete.Data;

namespace WifiParisComplete.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        private List<WifiHotspot> _hotspots;
        
        public MapViewModel (List<WifiHotspot> hotspots)
        {
            _hotspots = hotspots;
        }

    }
}
