using WifiParisComplete.Data;

namespace WifiParisComplete.XF.Services
{
    public interface INavigationService
    {
        void ShowHomePage ();
        void ShowWifiPage ();
		void ShowMap();
		void ShowMapFor (WifiHotspot wifiHotspot);
    }
}
