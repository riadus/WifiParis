using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using WifiParisComplete.Services;

namespace WifiParisComplete.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private INavigationService NavigationService { get; }
        public HomeViewModel (INavigationService navigationService)
        {
            NavigationService = navigationService;
            NavigationToWifiPageButtonText = "Aller à la page de la liste des points Wifi";
            NavigateToWifiPageCommand = new MvxCommand (NavigateToWifiPage);
        }

        public ICommand NavigateToWifiPageCommand { get; }

        private void NavigateToWifiPage ()
        {
            NavigationService.ShowWifiPage ();
        }

        public string NavigationToWifiPageButtonText { get; }
    }
}