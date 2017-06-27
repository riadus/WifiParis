using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace ServiceInutile
{
    [Activity(Label = "Service Inutile", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private bool _serviceStarted;
		private Button _startOrCancelButton;
		private Button _stopButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			_startOrCancelButton = FindViewById<Button>(Resource.Id.startOrCancelButton);
			_stopButton = FindViewById<Button>(Resource.Id.stopButton);

            _startOrCancelButton.Click += StartOrCancel_Click;
            _stopButton.Click += StopButton_Click;
        }

        protected override void OnDestroy()
        {
            _startOrCancelButton.Click -= StartOrCancel_Click;
            base.OnDestroy();
        }

        void StartOrCancel_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(MonService));
            if(_serviceStarted)
            {
                intent.PutExtra("Cancel", true);
				_startOrCancelButton.Text = "Start";
			}
            else
            {
                _startOrCancelButton.Text = "Cancel";
            }
			StartService(intent);
			_serviceStarted = !_serviceStarted;
        }

        void StopButton_Click(object sender, System.EventArgs e)
        {
			var intent = new Intent(this, typeof(MonService));
			StopService(intent);
		}
    }
}

