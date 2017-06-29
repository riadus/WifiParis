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
            
        }

        private async Task LoadWifiHotspots ()
        {
            
        }

        public string LoadMapButtonText { get; }
        public string LoadWifiHotspotsButtonText { get; }

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
            
        }

        public bool IsLoadMapAvailable => false;

    }
}