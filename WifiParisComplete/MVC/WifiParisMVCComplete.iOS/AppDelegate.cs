using Autofac;
using Foundation;
using SQLite.Net.Platform.XamarinIOS;
using UIKit;
using WifiParisComplete.Domain;
using WifiParisComplete.SqLite;
using WifiParisMVCComplete.Setup;

namespace WifiParisMVCComplete.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register ("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window {
            get;
            set;
        }

        public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method
            SetupDatabase ();
            return true;
        }

        public void SetupDatabase ()
        {
            var pathProvider = AppContainer.Container.Resolve<IFilePathProvider> ();
            var path = pathProvider.DatabasePath;
            SQLiteDatabase.FilePath = path;
            SQLiteDatabase.Initialize (new SQLitePlatformIOS ());
        }
    }
}
