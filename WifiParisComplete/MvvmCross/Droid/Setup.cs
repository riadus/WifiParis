using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using WifiParisComplete.Droid.IoC;
using WifiParisComplete.Services;

namespace WifiParisComplete.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup (Context applicationContext) : base(applicationContext)
        {
            
        }

        protected override IMvxApplication CreateApp ()
        {
            return new App ();
        }

        protected override void InitializePlatformServices ()
        {
			Mvx.RegisterType<IDeviceInfo, DeviceInfoDroid> ();
            base.InitializePlatformServices ();
        }
    }
}