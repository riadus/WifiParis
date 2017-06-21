
using Android.App;
using MvvmCross.Droid.Views;
using WifiParisComplete.ViewModels;

namespace WifiParisComplete.Droid
{
    [Activity (Label = "WifiHotspotsActivity")]
    public class WifiHotspotsActivity : MvxActivity<WifiHotspotsViewModel>
    {
        protected override void OnViewModelSet ()
        {
            SetContentView (Resource.Layout.HotspotsWifiView);
        }
    }
}
