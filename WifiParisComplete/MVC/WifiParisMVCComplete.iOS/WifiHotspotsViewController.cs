using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using WifiParisComplete.Data;
using System.Linq;
using WifiParisComplete.Domain.Interfaces;
using WifiParisComplete.Domain.Services;
using WifiParisMVCComplete.iOS;
using WifiParisComplete.Domain;

namespace WifiParisMVCComplete.iOS
{
    public partial class WifiHotspotsViewController : UIViewController
    {
        IBackendService _backendService;
        WifiHotspotViewSource _source;
        IEnumerable<WifiHotspot> _wifiHotspots;
        public WifiHotspotsViewController (IntPtr handle) : base (handle)
        {
            _backendService = new BackendService (new ApiClient (new MessageHandlerProviderIOS ()), new WifiHotspotMapper (new AddressMapper ()));
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
    }

    public class WifiHotspotViewSource : UITableViewSource
    {
        private List<WifiHotspot> _data;
        public void SetSource (IEnumerable<WifiHotspot> data)
        {
            _data = data.ToList ();
        }

        public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
        {
            var cellTemp = tableView.DequeueReusableCell ("Cell_Id");
            var cell = (WifiHotspotCell)cellTemp;
            cell.UpdateData (_data [indexPath.Row]);
            return cell;
        }

        public override nint RowsInSection (UITableView tableview, nint section)
        {
            return _data?.Count () ?? 0;
        }
    }
}