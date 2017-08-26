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
			NavigationToAddNewPageButtonText = "Ajouter un nouveau point Wifi";
			NavigateToWifiPageCommand = new MvxCommand(NavigateToWifiPage);
			NavigateToAddNewPageCommand = new MvxCommand (NavigateToAddNewPage);
        }

		public ICommand NavigateToWifiPageCommand { get; }
		public ICommand NavigateToAddNewPageCommand { get; }

        private void NavigateToWifiPage ()
        {
            NavigationService.ShowWifiPage ();
        }

		private void NavigateToAddNewPage()
		{
			NavigationService.ShowAddNew();
		}

		public string NavigationToWifiPageButtonText { get; }
		public string NavigationToAddNewPageButtonText { get; }
    }
}