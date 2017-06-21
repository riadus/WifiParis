using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Autofac;
using WifiParisComplete.Data;
using WifiParisMVCComplete.Setup;

namespace WifiParisMVCComplete.Droid
{
    [Activity (Label = "Carte")]
    public class HotspotsMapActivity : Activity, IOnMapReadyCallback, ILocationListener
    {
        private IUnitOfWork UnitOfWork { get; }
        private GoogleMap _googleMap;
        private MapFragment _mapFragment;
        private bool _mapSet;
        private IEnumerable<WifiHotspot> _wifiHotspots;
        public IEnumerable<WifiHotspot> ValidHostpots => _wifiHotspots.Where (x => x.Coordinates != null 
                                                                              && x.Coordinates.Latitude > 0 
                                                                              && x.Coordinates.Longitude > 0);

        public HotspotsMapActivity ()
        {
            UnitOfWork = AppContainer.Container.Resolve<IUnitOfWork> ();
        }
        public void OnMapReady (GoogleMap googleMap)
        {
            _googleMap = googleMap;
            InitializeLocationManager ();
            LoadMarkers ();
        }

        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);
            SetContentView (Resource.Layout.HotspotsMapView);
            _wifiHotspots = UnitOfWork.GetAllWifiHotspots ();
            if (Intent.HasExtra ("selectedId")) {
                var id = Intent.Extras.GetInt ("selectedId");
                _wifiHotspots = _wifiHotspots.Where (x => x.Id == id);
            }
            InitMapFragment ();
        }

        void InitMapFragment ()
        {
            _mapFragment = FragmentManager.FindFragmentByTag ("map") as MapFragment;
            if (_mapFragment == null) {
                GoogleMapOptions mapOptions = new GoogleMapOptions ()
                    .InvokeMapType (GoogleMap.MapTypeNormal)
                    .InvokeZoomControlsEnabled (true);

                FragmentTransaction fragTx = FragmentManager.BeginTransaction ();
                _mapFragment = MapFragment.NewInstance (mapOptions);
                fragTx.Add (Resource.Id.hostpotsMap, _mapFragment, "map");
                fragTx.Commit ();
            }
            _mapFragment.GetMapAsync (this);
        }

        private void SetupMap (LatLng latLng)
        {
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder ();
            builder.Target (latLng);
            builder.Zoom (14);
            // builder.Bearing (155); Décallage par rapport au nord
            // builder.Tilt (65); 3D
            CameraPosition cameraPosition = builder.Build ();


            _googleMap.AnimateCamera (CameraUpdateFactory.NewCameraPosition (cameraPosition));
        }

        void InitializeLocationManager ()
        {
            var locationManager = (LocationManager)GetSystemService (LocationService);
            Criteria criteriaForLocationService = new Criteria {
                Accuracy = Accuracy.Fine
            };
            IList<string> acceptableLocationProviders = locationManager.GetProviders (criteriaForLocationService, true);

            if (acceptableLocationProviders.Any ()) {
                var locationProvider = acceptableLocationProviders.First ();
                locationManager.RequestLocationUpdates (locationProvider, 0, 0, this);
            }
        }

        public void OnLocationChanged (Location location)
        {
            if (location != null && !_mapSet) {
                //SetupMap (location);
                _mapSet = true;
            }
        }

        public void OnProviderDisabled (string provider)
        {
        }

        public void OnProviderEnabled (string provider)
        {
        }

        public void OnStatusChanged (string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
        }

        private void LoadMarkers ()
        {
            var atLeastOneMarker = false;
            foreach (var hotspot in ValidHostpots) {
                var markerOption = new MarkerOptions ();
                markerOption.SetPosition (new LatLng (hotspot.Coordinates.Latitude, hotspot.Coordinates.Longitude));
                markerOption.SetTitle (hotspot.Name);
                markerOption.SetSnippet (hotspot.Address.Street);
                if (!atLeastOneMarker) {
                    SetupMap (new LatLng (hotspot.Coordinates.Latitude, hotspot.Coordinates.Longitude));
                }
                _googleMap.AddMarker (markerOption);
            }
        }
    }
}