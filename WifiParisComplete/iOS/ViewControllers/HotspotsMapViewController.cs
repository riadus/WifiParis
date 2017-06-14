using System;
using System.Drawing;
using System.Linq;
using CoreLocation;
using Foundation;
using MapKit;
using MvvmCross.iOS.Views;
using UIKit;
using WifiParisComplete.Data;
using WifiParisComplete.ViewModels;

namespace WifiParisComplete.iOS
{
    public partial class HotspotsMapViewController : MvxViewController<HotspotsMapViewModel>
    {
        public HotspotsMapViewController () : base ("HotspotsMapView", null)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            SetupAnnotations ();
        }

        private void SetupMap (CLLocationCoordinate2D coords)
        {
            var locationManager = new CLLocationManager ();
            locationManager.RequestWhenInUseAuthorization ();
            MapView.ShowsUserLocation = true;
            var span = new MKCoordinateSpan (MilesToLatitudeDegrees (2), MilesToLongitudeDegrees (2, coords.Latitude));
            MapView.Region = new MKCoordinateRegion (coords, span);
        }

        public double MilesToLatitudeDegrees (double miles)
        {
            double earthRadius = 3960.0; // in miles
            double radiansToDegrees = 180.0 / Math.PI;
            return (miles / earthRadius) * radiansToDegrees;
        }

        public double MilesToLongitudeDegrees (double miles, double atLatitude)
        {
            double earthRadius = 3960.0; // in miles
            double degreesToRadians = Math.PI / 180.0;
            double radiansToDegrees = 180.0 / Math.PI;
            // derive the earth's radius at that point in latitude
            double radiusAtLatitude = earthRadius * Math.Cos (atLatitude * degreesToRadians);
            return (miles / radiusAtLatitude) * radiansToDegrees;
        }

        private void SetupAnnotations ()
        {
            foreach (var wifiHotspot in ViewModel.ValidHotspots) {
                
                var coords = new CLLocationCoordinate2D (wifiHotspot.Coordinates.Latitude, wifiHotspot.Coordinates.Longitude);
                var annotation = new WifiHotspotMapAnnotation (coords,
                                                               wifiHotspot.Name,
                                                               wifiHotspot.Address.Street);
                if (!MapView.Annotations.Any()) {
                    SetupMap (coords);
                }
                MapView.AddAnnotation (annotation);
            }
        }

        class WifiHotspotMapAnnotation : MKAnnotation
        {
            private CLLocationCoordinate2D _coord;
            private string _title, _subtitle;

            public override CLLocationCoordinate2D Coordinate {
                get { return _coord; }
            }
            public override void SetCoordinate (CLLocationCoordinate2D value)
            {
                _coord = value;
            }
            public override string Title {
                get { return _title; }
            }
            public override string Subtitle {
                get { return _subtitle; }
            }
            public WifiHotspotMapAnnotation (CLLocationCoordinate2D coordinate, string title, string subtitle)
            {
                _coord = coordinate;
                _title = title;
                _subtitle = subtitle;
            }
        }
    }
}