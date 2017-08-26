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
            LoadMoreWifiHotspotsCommand = new MvxAsyncCommand (LoadMoreWifiHotspots);
            AddWifiHotspotCommand = new MvxAsyncCommand(AddWifiHotspot);
            LoadMapCommand = new MvxCommand (LoadMap);
            LoadWifiHotspotsButtonText = "Charger la liste des points Wifi";
            FilterPlaceholder = "Filtre par code postal";
            LoadMapButtonText = "Charger la carte";
        }

        public ICommand LoadMapCommand { get; }
        public ICommand LoadWifiHotspotsCommand { get; }
		public ICommand LoadMoreWifiHotspotsCommand { get; }
        public ICommand AddWifiHotspotCommand { get; }

        private async Task LoadMoreWifiHotspots ()
        {
            BusyCounter++;
            if (_canLoadMore) {
                var newHostpots = await BackendService.GetMoreWifiHotspots (Filter).ConfigureAwait (false);
                _hotspots.AddRange (newHostpots);
                foreach (var item in newHostpots.Select (item => new WifiHotspotItemViewModel (item))) {
                    WifiHotspotsList.Add (item);
                }
            }
            BusyCounter--;
        }

        private async Task LoadWifiHotspots ()
        {
            BusyCounter++;
            UnitOfWork.DeleteAllWifiHotspots ();
            _hotspots = (await BackendService.GetWifiHotspots (Filter).ConfigureAwait (false)).ToList();
            WifiHotspotsList = new MvxObservableCollection<WifiHotspotItemViewModel>(_hotspots.Select (item => new WifiHotspotItemViewModel (item)));
            _canLoadMore = true;
            BusyCounter--;
        }

        private async Task AddWifiHotspot()
        {
            BusyCounter++;
            var hotspotWifi = new WifiHotspot
            {
                Address = new Address{
                    City = "Nantes",
                    PostalCode = "44000",
                    Street = "1 Rue de Rennes",
                },
                Id = 0,//_hotspots.Count(),
                SiteId = "",//_hotspots.Count().ToString(),
                Name = "New Nantes",
                Coordinates = new Coordinates{
                    Latitude = 58,
                    Longitude = 2
                }
            };
            await BackendService.AddWifiHotspot(hotspotWifi).ConfigureAwait(false);
            BusyCounter--;
        }

        public string LoadMapButtonText { get; }
        public string LoadWifiHotspotsButtonText { get; }
        MvxObservableCollection<WifiHotspotItemViewModel> _wifiHotspotsList;

        public MvxObservableCollection<WifiHotspotItemViewModel> WifiHotspotsList {
            get {
                return _wifiHotspotsList;
            }

            set {
                _wifiHotspotsList = value;
                RaisePropertyChanged ();
                RaisePropertyChanged (nameof (IsLoadMapAvailable));
            }
        }

        private string _filter;
        public string Filter {
            get {
                return _filter;
            }

            private set {
                _filter = value;
                _canLoadMore = false;
                RaisePropertyChanged ();
            }
        }

        private bool _canLoadMore;

        public string FilterPlaceholder { get; }

        private void LoadMap ()
        {
            UnitOfWork.SaveWifiHotspots (_hotspots);
            NavigationService.ShowMap ();
        }

        public bool IsLoadMapAvailable => WifiHotspotsList.Count () > 0;
    }
}