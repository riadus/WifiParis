using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using WifiParisComplete.Domain.Attributes;

namespace WifiParisMVCComplete.Setup
{
    public static class ContainerBuilderExtensions
    {
		public static void RegisterServicesForAssembly(this ContainerBuilder containerBuilder, Assembly assembly)
		{
            var creatableTypes = assembly.CreatableTypes();
			var singletons = creatableTypes.WithAttribute<RegisterInterfaceAsLazySingletonAttribute>().ToArray();
			var dynamicTypes = creatableTypes.WithAttribute<RegisterInterfaceAsDynamicAttribute>().ToArray();
			containerBuilder.RegisterTypes(singletons, true);
			containerBuilder.RegisterTypes(dynamicTypes, false);
		}

		public static void RegisterTypes(this ContainerBuilder containerBuilder, IEnumerable<Type> types, bool asSingleton)
		{
			foreach (var type in types)
			{
				var registrationBuilder = containerBuilder.RegisterType(type).AsImplementedInterfaces();
				if (asSingleton)
				{
					registrationBuilder.SingleInstance();
				}
			}
		}
    }
}
