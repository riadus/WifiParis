using System;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using SQLite.Net.Platform.XamarinAndroid;
using WifiParisComplete.Domain;
using WifiParisComplete.SqLite;

namespace WifiParisComplete.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup (Context applicationContext) : base(applicationContext)
        {
            
        }

        protected override IMvxApplication CreateApp ()
        {
            SetupDatabase ();
            return new App ();
        }

        private void SetupDatabase ()
        {
            var pathProvider = Mvx.Resolve<IFilePathProvider> ();
            var path = pathProvider.DatabasePath;
            SQLiteDatabase.FilePath = path;
            SQLiteDatabase.Initialize (new SQLitePlatformAndroid ());
        }

        protected override void InitializePlatformServices ()
        {
            Mvx.RegisterType<IFilePathProvider, FilePathProviderDroid> ();
            Mvx.RegisterType<IMessageHandlerProvider, MessageHandlerProviderDroid> ();
            base.InitializePlatformServices ();
        }
    }
}