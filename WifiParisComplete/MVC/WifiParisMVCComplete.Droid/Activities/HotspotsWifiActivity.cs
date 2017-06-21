
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Autofac;
using WifiParisComplete.Data;
using WifiParisComplete.Domain.Interfaces;
using WifiParisMVCComplete.Setup;

namespace WifiParisMVCComplete.Droid
{
    [Activity (Label = "HotspotsWifiActiviry")]
    public class HotspotsWifiActivity : Activity
    {
        private IUnitOfWork UnitOfWork { get; }
        private IBackendService BackendService {get;}
        private Button _loadHotspotsButton;
        private Button _loadMapButton;
        private EditText _postalCodeEditText;
        private ListView _hotspotListView;
        private IEnumerable<WifiHotspot> _wifiHotspots;
        public HotspotsWifiActivity ()
        {
            BackendService = AppContainer.Container.Resolve<IBackendService> ();
            UnitOfWork = AppContainer.Container.Resolve<IUnitOfWork> ();
        }

        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            SetContentView (Resource.Layout.HotspotsWifiView);
            _loadMapButton = FindViewById<Button> (Resource.Id.loadMapButton);
            _loadHotspotsButton = FindViewById<Button> (Resource.Id.loadHotspotsButton);
            _postalCodeEditText = FindViewById<EditText> (Resource.Id.postalCodeFilter);
            _hotspotListView = FindViewById<ListView> (Resource.Id.hotspotList);
            _loadMapButton.Click += _loadMapButton_Click;
            _loadHotspotsButton.Click += _loadHotspotsButton_Click;
            _hotspotListView.ItemClick += _hotspotListView_ItemClick;
        }

        void _loadMapButton_Click (object sender, System.EventArgs e)
        {
            UnitOfWork.DeleteAllWifiHotspots ();
            UnitOfWork.SaveWifiHotspots (_wifiHotspots);

            StartActivity (typeof (HotspotsMapActivity));
        }

        async void _loadHotspotsButton_Click (object sender, System.EventArgs e)
        {
            _wifiHotspots = await BackendService.GetWifiHotspots (_postalCodeEditText.Text);
            _hotspotListView.Adapter = new HotspotsAdapter (this, _wifiHotspots);
        }

        protected override void OnDestroy ()
        {
            _hotspotListView.ItemClick -= _hotspotListView_ItemClick;
            _loadMapButton.Click -= _loadMapButton_Click;
            _loadHotspotsButton.Click -= _loadHotspotsButton_Click;
            base.OnDestroy ();
        }

        void _hotspotListView_ItemClick (object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent (this, typeof (HotspotsMapActivity));
            var hotspotWifi = _wifiHotspots.ElementAt (e.Position);
            UnitOfWork.DeleteAllWifiHotspots ();
            UnitOfWork.SaveWifiHotspots (new List<WifiHotspot> { hotspotWifi });
            intent.PutExtra ("selectedId", hotspotWifi.Id);
            StartActivity (intent);
        }
    }
}
