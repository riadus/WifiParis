using System;
using MvvmCross.Core.ViewModels;
using WifiParisComplete.ViewModels;

namespace WifiParisComplete
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        public void Start (object hint = null)
        {
            ShowViewModel<HomeViewModel> ();
        }
    }
}
