using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
    }
}