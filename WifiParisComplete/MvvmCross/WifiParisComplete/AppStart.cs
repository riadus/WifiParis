using System;
using MvvmCross.Core.ViewModels;
using WifiParisComplete.Services;
using WifiParisComplete.ViewModels;

namespace WifiParisComplete
{
    public class AppStart : IMvxAppStart
    {
        private INavigationService NavigationService { get; }
        public AppStart (INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        public void Start (object hint = null)
        {
            NavigationService.ShowHomePage ();
        }
    }
}
