using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using WifiParisComplete.Data;
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

        public void ShowMap ()
        {
            ShowViewModel<HotspotsMapViewModel> ();
        }

        public void ShowWifiPage ()
        {
            ShowViewModel<WifiHotspotsViewModel> ();
        }
    }
}
