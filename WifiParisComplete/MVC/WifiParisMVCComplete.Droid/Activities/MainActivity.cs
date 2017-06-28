using Android.App;
using Android.Widget;
using Android.OS;

namespace WifiParisMVCComplete.Droid.Activities
{
    [Activity(MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private Button _button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            _button = FindViewById<Button>(Resource.Id.navigationButton);

            _button.Click += HandleButtonClick;
        }

        void HandleButtonClick (object sender, System.EventArgs e)
        {
            StartActivity (typeof (HotspotsWifiActivity));
        }

        protected override void OnDestroy ()
        {
            _button.Click -= HandleButtonClick;
            base.OnDestroy ();
        }
    }
}

