using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using WifiParisComplete.Data;
using WifiParisComplete.Domain.Interfaces;
using WifiParisComplete.Services;

namespace WifiParisComplete.ViewModels
{
    public class WifiHotspotsViewModel : BaseViewModel
    {
        private IBackendService BackendService { get; }
        private IUnitOfWork UnitOfWork { get; }
        private INavigationService NavigationService { get; }
        private List<WifiHotspot> _hotspots;
        public WifiHotspotsViewModel (IBackendService backendService, IUnitOfWork unitOfWork, INavigationService navigationService)
        {
            BackendService = backendService;
            UnitOfWork = unitOfWork;
            NavigationService = navigationService;
            LoadWifiHotspotsCommand = new MvxAsyncCommand (LoadWifiHotspots);
            LoadMapCommand = new MvxCommand (LoadMap);
            LoadWifiHotspotsButtonText = "Charger la liste des points Wifi";
            FilterPlaceholder = "Filtre par code postal";
            LoadMapButtonText = "Charger la carte";
        }

        public ICommand LoadMapCommand { get; }
        public ICommand LoadWifiHotspotsCommand { get; }

        private async Task LoadWifiHotspots ()
        {
            BusyCounter++;
            _hotspots = await BackendService.GetWifiHotspots (Filter).ConfigureAwait (false);
            WifiHotspotsList = _hotspots.Select (item => new WifiHotspotItemViewModel (item)).ToList ();
            BusyCounter--;
        }

        public string LoadMapButtonText { get; }
        public string LoadWifiHotspotsButtonText { get; }


        private IEnumerable<WifiHotspotItemViewModel> _wifiHotspotsList;

        public IEnumerable<WifiHotspotItemViewModel> WifiHotspotsList {
            get {
                return _wifiHotspotsList;
            }
            private set {
                SetProperty (ref _wifiHotspotsList, value);
                RaiseAllPropertiesChanged ();
            }
        }

        public string Filter { get; private set; }
        public string FilterPlaceholder { get; }

        private void LoadMap ()
        {
            UnitOfWork.WifiHotspotRepository.Save (_hotspots);
            NavigationService.ShowMap ();
        }

        public bool IsLoadMapAvailable => WifiHotspotsList.Count () > 0;
    }
}