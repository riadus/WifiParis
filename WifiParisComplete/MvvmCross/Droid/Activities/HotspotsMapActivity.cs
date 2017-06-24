using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using MvvmCross.Droid.Views;
using WifiParisComplete.ViewModels;

namespace WifiParisComplete.Droid
{
    [Activity (Label = "Carte")]
    public class HotspotsMapActivity : MvxActivity<HotspotsMapViewModel>, IOnMapReadyCallback, ILocationListener
    {
        private GoogleMap _googleMap;
        private MapFragment _mapFragment;
        private bool _mapSet;

        public void OnMapReady (GoogleMap googleMap)
        {
            _googleMap = googleMap;
            InitializeLocationManager ();
            LoadMarkers ();
        }

        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);
            SetContentView (Resource.Layout.HotspotsMapView);
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
            if (ViewModel == null) return;
            var atLeastOneMarker = false;
            foreach (var hotspot in ViewModel.ValidHotspots) {
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

