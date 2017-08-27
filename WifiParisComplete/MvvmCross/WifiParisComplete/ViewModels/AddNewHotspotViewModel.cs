using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using WifiParisComplete.Data;
using WifiParisComplete.Domain.Interfaces;
using WifiParisComplete.Services;

namespace WifiParisComplete.ViewModels
{
    public class AddNewHotspotViewModel : BaseViewModel
    {
		private IBackendService BackendService { get; }
		private IDeviceInfo DeviceInfo { get; }
        private WifiHotspot _wifiHotspot;
        public AddNewHotspotViewModel(IBackendService backendService, IDeviceInfo deviceInfo)
        {
			OkCommand = new MvxAsyncCommand(Ok);
            CancelCommand = new MvxCommand(Cancel);
            BackendService = backendService;
            DeviceInfo = deviceInfo;
            InitModel();
            SetEndOfLabels();
        }

        private void SetEndOfLabels()
        {
            _endOfLabels = DeviceInfo.Brand == DevicePlatform.iOS ? " :" : string.Empty;
        }

        private void InitModel()
        {
			_wifiHotspot = new WifiHotspot
			{
				Address = new Address(),
				Coordinates = new Coordinates()
			};
        }
        private string _endOfLabels;
        public string TitleLabel => "Ajouter une nouvelle borne";
		public string NameLabel => $"Nom de la borne{_endOfLabels}";
        public string AddressLabel => $"Adresse{_endOfLabels}";
        public string PostalCodeLabel => $"Code postal{_endOfLabels}";
        public string CityLabel => $"Ville{_endOfLabels}";
		public string LatLabel => $"Lattitude{_endOfLabels}";
		public string LongLabel => $"Longitude{_endOfLabels}";

        public string OkButtonTxt => "Ajouter";
        public string CancelButtonTxt => "Annuler saisie";

		public bool IsNameValid { get; private set; }
		public bool IsAddressValid { get; private set; }
		public bool IsPostalCodeValid { get; private set; }
		public bool IsCityValid { get; private set; }
		public bool IsLatValid { get; private set; }
		public bool IsLongValid { get; private set; }

        private bool IsModelValid => IsNameValid && 
            IsAddressValid && 
            IsPostalCodeValid && 
            IsCityValid &&  
            IsLatValid && 
            IsLongValid;

        public string Name
        {
            get { return _wifiHotspot.Name; }
            set
            {
                _wifiHotspot.Name = value;
                Validate();
            }
        }

		public string Address
		{
			get { return _wifiHotspot.Address.Street; }
            set { _wifiHotspot.Address.Street = value;
				Validate();
			}
		}

		public string PostalCode
		{
			get { return _wifiHotspot.Address.PostalCode; }
			set { _wifiHotspot.Address.PostalCode = value;
				Validate();
			}
		}

		public string City
		{
			get { return _wifiHotspot.Address.City; }
			set { _wifiHotspot.Address.City = value;
				Validate();
			}
		}

        private string _lat;
        public string Lat
        {
            get
            {
                return _lat;
            }

            set
            {
                _lat = value;
				Validate();
			}
        }

        private string _long;
        public string Long
        {
            get
            {
                return _long;
            }

            set
            {
                _long = value;
				Validate();
			}
        }

        public IMvxCommand OkCommand { get; }
        public IMvxCommand CancelCommand { get; }

        private async Task Ok()
        {
            if (IsModelValid)
            {
                await BackendService.AddWifiHotspot(_wifiHotspot).ConfigureAwait(false);
                Close(this);
            }
        }

        private void Cancel()
        {
            InitModel();
            Lat = string.Empty;
            Long = string.Empty;
            RaiseAllPropertiesChanged();
        }

        private void Validate()
        {
			IsNameValid = !string.IsNullOrEmpty(Name);
			IsAddressValid = !string.IsNullOrEmpty(Address);
			IsPostalCodeValid = !string.IsNullOrEmpty(PostalCode);
			IsCityValid = !string.IsNullOrEmpty(City);

            double lat, longitude;

            IsLatValid = Double.TryParse(Lat, out lat);
			IsLongValid = Double.TryParse(Long, out longitude);
            if(IsLatValid)
            {
                _wifiHotspot.Coordinates.Latitude = lat;
            }
            if(IsLongValid)
            {
                _wifiHotspot.Coordinates.Longitude = longitude;
            }
            RaiseAllPropertiesChanged();
        }
    }
}
