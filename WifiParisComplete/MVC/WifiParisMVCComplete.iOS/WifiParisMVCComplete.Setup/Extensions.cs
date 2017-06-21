using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using WifiParisComplete.Domain.Attributes;

namespace WifiParisMVCComplete.Setup
{
    public static class Extensions
    {
        public static IEnumerable<Type> ExceptionSafeGetTypes (this Assembly assembly)
        {
            try {
                return assembly.GetTypes ();
            } catch
            {
                return new Type [0];
            }
        }

        public static IEnumerable<Type> CreatableTypes (this Assembly assembly)
        {
            return assembly
                .ExceptionSafeGetTypes ()
                .Where (t => !t.IsAbstract)
                .Where (t => t.GetConstructors (BindingFlags.Instance | BindingFlags.Public).Any ());
        }

        public static IEnumerable<Type> GetTypes (this Assembly assembly)
        {
            foreach (var type in assembly.DefinedTypes)
                yield return type.AsType ();
        }

        public static IEnumerable<Type> WithAttribute (this IEnumerable<Type> types, Type attributeType)
        {
            return types.Where (x => x.GetCustomAttributes (attributeType, true).Any ());
        }

        public static IEnumerable<Type> WithAttribute<TAttribute> (this IEnumerable<Type> types)
            where TAttribute : Attribute
        {
            return types.WithAttribute (typeof (TAttribute));
        }

        public static void RegisterServicesForAssembly (this ContainerBuilder containerBuilder, Assembly assembly)
        {
            var creatableTypes = assembly.CreatableTypes ().ToList ();
            var singletons = creatableTypes.WithAttribute<RegisterInterfaceAsLazySingletonAttribute> ().ToArray ();
            var dynamicTypes = creatableTypes.WithAttribute<RegisterInterfaceAsDynamicAttribute> ().ToArray ();
            containerBuilder.RegisterTypes (singletons, true);
            containerBuilder.RegisterTypes (dynamicTypes, false);
        }

        public static void RegisterTypes (this ContainerBuilder containerBuilder, IEnumerable<Type> types, bool asSingleton)
        {
            foreach (var type in types) {
                var registrationBuilder = containerBuilder.RegisterType (type).AsImplementedInterfaces ();
                if (asSingleton) {
                    registrationBuilder.SingleInstance ();
                }
            }
        }
    }
}