using System;
using System.Collections.Generic;
using System.Linq;
using WifiParisComplete.Data;

namespace WifiParisComplete.XF.ViewModels
{
    public class HotspotsMapViewModel : BaseViewModel
    {
        private IEnumerable<WifiHotspot> _hotspots;
        private IUnitOfWork UnitOfWork { get; }        
        public HotspotsMapViewModel (IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void Start(WifiHotspot wifiHotspot = null)
        {
            if (wifiHotspot != null)
            {
                _hotspots = new List<WifiHotspot> { wifiHotspot };
            }
            else
            {
                _hotspots = UnitOfWork.GetAllWifiHotspots();
            }
        }

        public IEnumerable<WifiHotspot> ValidHotspots => _hotspots.Where(x => x.Coordinates != null && x.Coordinates.Latitude > 0 && x.Coordinates.Longitude > 0);
    }
}
