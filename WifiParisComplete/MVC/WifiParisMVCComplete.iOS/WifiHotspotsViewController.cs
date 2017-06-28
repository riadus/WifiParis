using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using UIKit;
using WifiParisComplete.Data;
using WifiParisComplete.Domain.Interfaces;
using WifiParisMVCComplete.Setup;

namespace WifiParisMVCComplete.iOS
{
    public partial class WifiHotspotsViewController : UIViewController
    {
        private readonly IBackendService _backendService;
        private readonly IUnitOfWork _unitOfWork;
        private IEnumerable<WifiHotspot> _wifiHotspots;

        public WifiHotspotsViewController (IntPtr handle) : base (handle)
        {
            _backendService = AppContainer.Container.Resolve<IBackendService> ();
            _unitOfWork = AppContainer.Container.Resolve<IUnitOfWork> ();
            _wifiHotspots = new List<WifiHotspot> ();
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            UpdateUI ();
        }

        private void SetBusiness (bool isBusy)
        {
            View.BackgroundColor = isBusy ? UIColor.Orange : UIColor.White;
        }

        void UpdateUI ()
        {
            LoadMapButton.Enabled = CanLoadMapForAll;
        }

        private bool CanLoadMapForAll => _wifiHotspots.Count () > 0;

        public override bool ShouldPerformSegue (string segueIdentifier, Foundation.NSObject sender)
        {
            if (segueIdentifier == "LoadMapSegue") {
                return CanLoadMapForAll;
            }
            return base.ShouldPerformSegue (segueIdentifier, sender);
        }
    }
}