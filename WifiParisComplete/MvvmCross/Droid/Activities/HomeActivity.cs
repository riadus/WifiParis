using Android.App;
using MvvmCross.Droid.Views;
using WifiParisComplete.ViewModels;

namespace WifiParisComplete.Droid.Activities
{
    [Activity (Label = "Wifi Paris Complete", MainLauncher = true, Icon = "@mipmap/icon")]
    public class HomeActivity : MvxActivity<HomeViewModel>
    {
        protected override void OnViewModelSet ()
        {
            SetContentView (Resource.Layout.HomeView);
        }
    }
}

