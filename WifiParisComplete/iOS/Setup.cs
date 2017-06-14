using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;

namespace WifiParisComplete.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup (IMvxApplicationDelegate applicationDelegate, UIKit.UIWindow window) : base(applicationDelegate, window)
        {

        }

        protected override IMvxApplication CreateApp ()
        {
            return new App ();
        }
    }
}
