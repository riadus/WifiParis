using System.Reflection;
using Autofac;
#if __IOS__
using SQLite.Net.Platform.XamarinIOS;
#endif
#if __ANDROID__
using SQLite.Net.Platform.XamarinAndroid;
#endif
using WifiParisComplete.Domain;
using WifiParisComplete.SqLite;

namespace WifiParisMVCComplete.Setup
{
    public class AppSetup
    {
        public IContainer CreateContainer ()
        {
            var containerBuilder = new ContainerBuilder ();
            RegisterDependencies (containerBuilder);
            return containerBuilder.Build ();
        }

        protected virtual void RegisterDependencies (ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterServicesForAssembly (typeof (DomainAssemblyReference).GetTypeInfo ().Assembly);
            containerBuilder.RegisterServicesForAssembly (GetType ().GetTypeInfo ().Assembly);
            containerBuilder.RegisterServicesForAssembly (typeof (SQLiteReferenceAssembly).GetTypeInfo ().Assembly);
        }

        public static void SetupDatabase ()
        {
            var pathProvider = AppContainer.Container.Resolve<IFilePathProvider> ();
            var path = pathProvider.DatabasePath;
            SQLiteDatabase.FilePath = path;
#if __ANDROID__
            SQLiteDatabase.Initialize (new SQLitePlatformAndroid ());
#endif
#if __IOS__
            SQLiteDatabase.Initialize (new SQLitePlatformIOS ());
#endif
        }
    }

    public static class AppContainer
    {
        static IContainer _container;

        public static IContainer Container {
            get {
                return _container ?? (_container = new AppSetup().CreateContainer());
            }
        }
    }

}
