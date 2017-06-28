using System.Reflection;
using Autofac;
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
