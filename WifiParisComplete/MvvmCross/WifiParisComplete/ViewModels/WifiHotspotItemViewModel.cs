using WifiParisComplete.Data;

namespace WifiParisComplete.ViewModels
{
    public class WifiHotspotItemViewModel : BaseViewModel
    {
        private WifiHotspot WifiHotspot { get; }
        public WifiHotspotItemViewModel (WifiHotspot wifiHotspot)
        {
            WifiHotspot = wifiHotspot;
        }

        public string Address => WifiHotspot.Address.Street;
        public string PostalCode => WifiHotspot.Address.PostalCode;
        public string Name => WifiHotspot.Name;
        public string Distance => "";
    }
}
