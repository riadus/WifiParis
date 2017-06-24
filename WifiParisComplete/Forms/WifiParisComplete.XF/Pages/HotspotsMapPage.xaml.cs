using System.Linq;
using WifiParisComplete.Data;
using WifiParisComplete.XF.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WifiParisComplete.XF.Pages
{
    public partial class HotspotsMapPage : ContentPage
    {
        private WifiHotspot WifiHotspot { get; }
        public HotspotsMapPage(WifiHotspot wifiHotspot = null)
        {
            InitializeComponent();
            BindingContext = ViewModel;
            WifiHotspot = wifiHotspot;
        }

		private HotspotsMapViewModel ViewModel => App.Locator.HotspotsMap;

		protected override void OnAppearing()
		{
			base.OnAppearing();
            ViewModel.Start(WifiHotspot);
			SetupAnnotations();
		}

		private void SetupAnnotations()
		{
			foreach (var wifiHotspot in ViewModel.ValidHotspots)
			{
				var position = new Position(wifiHotspot.Coordinates.Latitude, wifiHotspot.Coordinates.Longitude);
				var pin = new Pin
				{
					Type = PinType.Place,
					Position = position,
					Label = wifiHotspot.Name,
					Address = wifiHotspot.Address.Street
				};
                if(!Carte.Pins.Any())
                {
					Carte.MoveToRegion(
	                    MapSpan.FromCenterAndRadius(position, Distance.FromMiles(2)));
                }
				Carte.Pins.Add(pin);
			}
		}
	}
}
