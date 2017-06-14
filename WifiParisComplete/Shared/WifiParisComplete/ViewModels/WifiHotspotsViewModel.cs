using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using WifiParisComplete.Domain.Interfaces;

namespace WifiParisComplete.ViewModels
{
    public class WifiHotspotsViewModel : BaseViewModel
    {
        private IBackendService BackendService { get; }
        public WifiHotspotsViewModel (IBackendService backendService)
        {
            BackendService = backendService;
            LoadWifiHotspotsCommand = new MvxAsyncCommand (LoadWifiHotspots);
            LoadWifiHotspotsButtonText = "Charger la liste des points Wifi";
            FilterPlaceholder = "Filtre par code postal";
        }

        public ICommand LoadWifiHotspotsCommand { get; }

        private async Task LoadWifiHotspots ()
        {
            BusyCounter++;
            var hotspots = await BackendService.GetWifiHotspots (Filter).ConfigureAwait (false);
            WifiHotspotsList = hotspots.Select (item => new WifiHotspotItemViewModel (item)).ToList ();
            BusyCounter--;
        }

        public string LoadWifiHotspotsButtonText { get; }
        IEnumerable<WifiHotspotItemViewModel> _wifiHotspotsList;

        public IEnumerable<WifiHotspotItemViewModel> WifiHotspotsList {
            get {
                return _wifiHotspotsList;
            }
            private set {
                SetProperty (ref _wifiHotspotsList, value);
            }
        }

        public string Filter { get; private set; }
        public string FilterPlaceholder { get; }
    }
}