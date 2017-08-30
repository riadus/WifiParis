using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using WifiParisComplete.iOS.IoC;
using WifiParisComplete.Services;

namespace WifiParisComplete.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup (IMvxApplicationDelegate applicationDelegate, UIKit.UIWindow window) : base (applicationDelegate, window)
        {

        }

        protected override IMvxApplication CreateApp ()
        {
            return new App ();
        }

        protected override void InitializePlatformServices ()
        {
			Mvx.RegisterType<IDeviceInfo, DeviceInfoIOS> ();
            base.InitializePlatformServices ();
        }
    }
}