using MvvmCross.Core.ViewModels;
using WifiParisComplete.Domain.Attributes;
using WifiParisComplete.ViewModels;

namespace WifiParisComplete.Services
{
    [RegisterInterfaceAsDynamic]
    public class NavigationService : MvxNavigatingObject, INavigationService
    {
        public void ShowHomePage ()
        {
            ShowViewModel<HomeViewModel> ();
        }

        public void ShowWifiPage ()
        {
            ShowViewModel<WifiHotspotsViewModel> ();
        }
    }
}
