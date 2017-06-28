using GalaSoft.MvvmLight.Ioc;
#if __IOS__
using SQLite.Net.Platform.XamarinIOS;
using WifiParisComplete.XF.iOS;
#endif
#if __ANDROID__
using WifiParisComplete.XF.Droid;
using SQLite.Net.Platform.XamarinAndroid;
#endif
using WifiParisComplete.Domain;
using WifiParisComplete.SqLite;

namespace WifiParisComplete.XF.Setup
{
    public static class Setup
    {
        public static void RegisterPlatformDependencies()
        {

#if __ANDROID__
            SimpleIoc.Default.Register<IFilePathProvider, FilePathProviderDroid>();
            SimpleIoc.Default.Register<IMessageHandlerProvider, MessageHandlerProviderDroid>();
#endif
#if __IOS__
			SimpleIoc.Default.Register<IFilePathProvider, FilePathProviderIOS>();
			SimpleIoc.Default.Register<IMessageHandlerProvider, MessageHandlerProviderIOS>();
#endif
        }
    }
}
