using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using WifiParisComplete.Data;
using WifiParisComplete.Domain.Interfaces;

namespace WifiParisComplete.ViewModels
{
    public class AddNewHotspotViewModel : BaseViewModel
    {
        private IBackendService BackendService { get; }
        private WifiHotspot _wifiHotspot;
        public AddNewHotspotViewModel(IBackendService backendService)
        {
			OkCommand = new MvxAsyncCommand(Ok);
            CancelCommand = new MvxCommand(Cancel);
            BackendService = backendService;
            InitModel();
        }

        private void InitModel()
        {
			_wifiHotspot = new WifiHotspot
			{
				Address = new Address(),
				Coordinates = new Coordinates()
			};
        }

        public string TitleLabel => "Ajouter une nouvelle borne";
		public string NameLabel => "Nom de la borne :";
		public string AddressLabel => "Adresse :";
        public string PostalCodeLabel => "Code postal :";
        public string CityLabel => "Ville :";
		public string LatLabel => "Lattitude  :";
		public string LongLabel => "Longitude  :";

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
            set { _wifiHotspot.Name = value; }
        }

		public string Address
		{
			get { return _wifiHotspot.Address.Street; }
            set { _wifiHotspot.Address.Street = value; }
		}

		public string PostalCode
		{
			get { return _wifiHotspot.Address.PostalCode; }
			set { _wifiHotspot.Address.PostalCode = value; }
		}

		public string City
		{
			get { return _wifiHotspot.Address.City; }
			set { _wifiHotspot.Address.City = value; }
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
            }
        }

        public IMvxCommand OkCommand { get; }
        public IMvxCommand CancelCommand { get; }

        private async Task Ok()
        {
            Validate();
            if (IsModelValid)
            {
                await BackendService.AddWifiHotspot(_wifiHotspot).ConfigureAwait(false);
                Close(this);
            }
        }

        private void Cancel()
        {
            InitModel();
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
