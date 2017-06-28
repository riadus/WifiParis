using GalaSoft.MvvmLight.Ioc;
using WifiParisComplete.Data;
using WifiParisComplete.Domain;
using WifiParisComplete.Domain.API;
using WifiParisComplete.Domain.Interfaces;
using WifiParisComplete.Domain.Services;
using WifiParisComplete.SqLite;
using WifiParisComplete.XF.Pages;
using WifiParisComplete.XF.Services;
using WifiParisComplete.XF.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WifiParisComplete.XF
{
    public partial class App : Application
    {
        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage();
            RegisterDependencies();
            Start();
        }

        public void Start()
        {
            SimpleIoc.Default.GetInstance<INavigationService>().ShowHomePage();
		}

        public void RegisterDependencies()
        {
            SimpleIoc.Default.Register(() => MainPage.Navigation);
			SimpleIoc.Default.Register<INavigationService, NavigationService>();
			SimpleIoc.Default.Register<IBackendService, BackendService>();
			SimpleIoc.Default.Register<IApiClient, ApiClient>();
			SimpleIoc.Default.Register<IMapper<Fields, Address>, AddressMapper>();
			SimpleIoc.Default.Register<IMapper<Record, WifiHotspot>, WifiHotspotMapper>();
			SimpleIoc.Default.Register<IUnitOfWork, UnitOfWork>();
        }
    }
}