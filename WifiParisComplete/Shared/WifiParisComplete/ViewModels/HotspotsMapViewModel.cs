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
            _hotspots = UnitOfWork.WifiHotspotRepository.GetAll ().ToList();
        }
    }
}
