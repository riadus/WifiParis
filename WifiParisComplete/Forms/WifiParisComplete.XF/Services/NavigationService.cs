using System;
using WifiParisComplete.Data;
using WifiParisComplete.XF.Pages;
using Xamarin.Forms;

namespace WifiParisComplete.XF.Services
{
    public class NavigationService : INavigationService
    {
        private INavigation Navigation { get; }
        public NavigationService(INavigation navigation)
        {
            Navigation = navigation;
        }
        public void ShowHomePage()
        {
            Navigation.PushAsync(new HomePage());
        }

        public void ShowMap()
        {
			Navigation.PushAsync(new HotspotsMapPage());
		}

        public void ShowWifiPage()
        {
			Navigation.PushAsync(new WifiHotspotsPage());
		}

        public void ShowMapFor(WifiHotspot wifiHotspot)
        {
            Navigation.PushAsync(new HotspotsMapPage(wifiHotspot));
        }
    }
}
