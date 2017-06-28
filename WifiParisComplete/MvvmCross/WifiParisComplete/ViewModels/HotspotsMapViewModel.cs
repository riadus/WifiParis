using System;
using System.Collections.Generic;
using System.Linq;
using WifiParisComplete.Data;

namespace WifiParisComplete.ViewModels
{
    public class HotspotsMapViewModel : BaseViewModel
    {
        private List<WifiHotspot> _hotspots;
        private IUnitOfWork UnitOfWork { get; }        
        public HotspotsMapViewModel (IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public override void Start ()
        {
            base.Start ();
            _hotspots = UnitOfWork.GetAllWifiHotspots ().ToList();
        }

        public List<WifiHotspot> ValidHotspots => _hotspots.Where (x => x.Coordinates != null && x.Coordinates.Latitude > 0 && x.Coordinates.Longitude > 0).ToList ();
    }
}
