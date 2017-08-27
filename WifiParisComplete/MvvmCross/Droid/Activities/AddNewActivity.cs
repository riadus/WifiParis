
using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using WifiParisComplete.ViewModels;

namespace WifiParisComplete.Droid.Activities
{
    [Activity(Label = "AddNewActivity")]
    public class AddNewActivity : MvxActivity<AddNewHotspotViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AddNewView);
        }
    }
}
