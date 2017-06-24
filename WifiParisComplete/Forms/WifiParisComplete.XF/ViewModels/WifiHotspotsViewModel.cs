using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WifiParisComplete.Data;
using WifiParisComplete.Domain.Interfaces;
using WifiParisComplete.XF.Services;
using Xamarin.Forms;

namespace WifiParisComplete.XF.ViewModels
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
            LoadWifiHotspotsCommand = new Command (async() => await LoadWifiHotspots());
            LoadMoreWifiHotspotsCommand = new Command (async () => await LoadMoreWifiHotspots());
            LoadMapCommand = new Command (LoadMap);
            LoadWifiHotspotsButtonText = "Charger la liste des points Wifi";
            FilterPlaceholder = "Filtre par code postal";
            LoadMapButtonText = "Charger la carte";
        }

        public ICommand LoadMapCommand { get; }
        public ICommand LoadWifiHotspotsCommand { get; }
        public ICommand LoadMoreWifiHotspotsCommand { get; }

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
            WifiHotspotsList = new ObservableCollection<WifiHotspotItemViewModel>(_hotspots.Select (item => new WifiHotspotItemViewModel (item)));
            _canLoadMore = true;
            BusyCounter--;
        }

        public string LoadMapButtonText { get; }
        public string LoadWifiHotspotsButtonText { get; }
        ObservableCollection<WifiHotspotItemViewModel> _wifiHotspotsList;

        public ObservableCollection<WifiHotspotItemViewModel> WifiHotspotsList {
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

            set {
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

        public bool IsLoadMapAvailable => WifiHotspotsList?.Count() > 0;
        WifiHotspotItemViewModel _selectedHotspot;

        public WifiHotspotItemViewModel SelectedHotspot
        {
            get
            {
                return _selectedHotspot;
            }

            set
            {
                _selectedHotspot = value;
                if (SelectedHotspot != null)
                    NavigationService.ShowMapFor(SelectedHotspot.WifiHotspot);
            }
        }
    }
}