using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;

namespace ServiceInutile
{
    [Service]
    public class MonService : Service
    {
		const string tag = "Service Inutile";
		CancellationTokenSource _source = new CancellationTokenSource();

		bool isCancelled;
		bool isDownloaded;

		public override void OnCreate()
		{
			base.OnCreate();
			Log.Debug(tag, "Service created");
		}

		public override IBinder OnBind(Intent intent)
		{
			Log.Debug(tag, "OnBind called");

            return new BinderUtile(this);
		}

		public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
		{
			Log.Debug(tag, "OnStartCommand called");

			isDownloaded = false;
			isCancelled = false;


			var cancel = intent.GetBooleanExtra("Cancel", false);
            if(cancel)
            {
				Toast.MakeText(this, "Download Cancelled", ToastLength.Short).Show();
				_source.Cancel();
                return StartCommandResult.RedeliverIntent;
			}
            else
            {
				Toast.MakeText(this, "Download Started", ToastLength.Short).Show();
			}
			Task.Run(() =>
			{
				for (int i = 0; i < 10 && isCancelled == false; i++)
				{
					if (_source.Token.IsCancellationRequested)
					{
                        isDownloaded = false;
						StopSelf();
					}
					int percent = 100 * (i + 1) / 10;
					var msg = String.Format("[{0}] download in progress: {1}% complete", startId, percent);
					Log.Debug(tag, msg);

					Thread.Sleep(500);
				}

				isDownloaded = true;
				StopSelf();
			}, _source.Token);

			return StartCommandResult.RedeliverIntent;
		}

		public override void OnDestroy()
		{
			isCancelled = true;

			if (isDownloaded)
				Toast.MakeText(this, "Download Complete", ToastLength.Short).Show();
			else
				Toast.MakeText(this, "Download Cancelled", ToastLength.Short).Show();

			Log.Debug(tag, "Service destroyed");
		}
    }
}
