﻿using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using SQLite.Net.Platform.XamarinIOS;
using WifiParisComplete.Domain;
using WifiParisComplete.iOS.IoC;
using WifiParisComplete.iOS.Services;
using WifiParisComplete.Services;
using WifiParisComplete.SqLite;

namespace WifiParisComplete.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup (IMvxApplicationDelegate applicationDelegate, UIKit.UIWindow window) : base (applicationDelegate, window)
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
            SQLiteDatabase.Initialize (new SQLitePlatformIOS ());
        }

        protected override void InitializePlatformServices ()
        {
            Mvx.RegisterType<IFilePathProvider, FilePathProviderIOS>();
			Mvx.RegisterType<IMessageHandlerProvider, MessageHandlerProviderIOS>();
			Mvx.RegisterType<IDeviceInfo, DeviceInfoIOS> ();
            base.InitializePlatformServices ();
        }
    }
}