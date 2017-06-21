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
        IBackendService _backendService;
        WifiHotspotViewSource _source;
        IEnumerable<WifiHotspot> _wifiHotspots;
        public WifiHotspotsViewController (IntPtr handle) : base (handle)
        {
            _backendService = AppContainer.Container.Resolve<IBackendService> (); 
            _wifiHotspots = new List<WifiHotspot> ();
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            _source = new WifiHotspotViewSource ();
            WifiHotspotsTable.Source = _source;
            UpdateUI ();
        }

        async partial void LoadButton_TouchUpInside (UIButton sender)
        {
            SetBusiness (true);
            _wifiHotspots = await _backendService.GetWifiHotspots (FilterTextField.Text).ConfigureAwait (true);
            _source.SetSource (_wifiHotspots);
            WifiHotspotsTable.ReloadData ();
            UpdateUI ();
            SetBusiness (false);
        }

        private void SetBusiness (bool isBusy)
        {
            View.BackgroundColor = isBusy ? UIColor.Orange : UIColor.White;
        }

        void UpdateUI ()
        {
            LoadMapButton.Enabled = _wifiHotspots.Count() > 0;
        }

        public override void PrepareForSegue (UIStoryboardSegue segue, Foundation.NSObject sender)
        {
            base.PrepareForSegue (segue, sender);
            if (segue.Identifier == "CellSegue") {
                var destinationViewControler = segue.DestinationViewController as HotspotsMapViewController;
                destinationViewControler.WifiHotspot = ((WifiHotspotCell)sender).Model;
            }
        }
    }
}