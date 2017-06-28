using System.Windows.Input;
using WifiParisComplete.XF.Services;
using Xamarin.Forms;

namespace WifiParisComplete.XF.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private INavigationService NavigationService { get; }
        public HomeViewModel (INavigationService navigationService)
        {
            NavigationService = navigationService;
            NavigationToWifiPageButtonText = "Aller à la page de la liste des points Wifi";
            NavigateToWifiPageCommand = new Command (NavigateToWifiPage);
        }

        public ICommand NavigateToWifiPageCommand { get; }

        private void NavigateToWifiPage ()
        {
            NavigationService.ShowWifiPage ();
        }

        public string NavigationToWifiPageButtonText { get; }
    }
}