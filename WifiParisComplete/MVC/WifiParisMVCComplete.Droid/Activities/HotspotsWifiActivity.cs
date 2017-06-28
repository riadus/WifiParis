
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
    [Activity (Label = "Rechercher des bornes")]
    public class HotspotsWifiActivity : Activity
    {
        private IUnitOfWork UnitOfWork { get; }
        private IBackendService BackendService {get;}
        private Button _loadHotspotsButton;
        private Button _loadMapButton;
        private EditText _postalCodeEditText;

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
            _loadHotspotsButton.Click += _loadHotspotsButton_Click;
        }

        async void _loadHotspotsButton_Click (object sender, System.EventArgs e)
        {
            _wifiHotspots = await BackendService.GetWifiHotspots (_postalCodeEditText.Text);
        }

        protected override void OnDestroy ()
        {
            _loadHotspotsButton.Click -= _loadHotspotsButton_Click;
            base.OnDestroy ();
        }
    }
}
