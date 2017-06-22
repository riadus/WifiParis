using System.Reflection;
using Autofac;
using WifiParis.Sqlite;

namespace WifiParis.Setup
{
    public class AppSetup
    {
        public IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            RegisterDependencies(containerBuilder);
            return containerBuilder.Build();
        }

        protected virtual void RegisterDependencies(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterServicesForAssembly(typeof(Domain.DomainAssemblyReference).GetTypeInfo().Assembly);
            containerBuilder.RegisterServicesForAssembly(GetType().GetTypeInfo().Assembly);
            containerBuilder.RegisterServicesForAssembly(typeof(SQLiteReferenceAssembly).GetTypeInfo().Assembly);
        }
    }
}
