using System;
using System.Collections.Generic;
using Microsoft.Framework.DependencyInjection;
using StructureMap.Configuration.DSL.Expressions;
using StructureMap.Pipeline;

namespace StructureMap
{
    internal static class HelperExtensions
    {
        public static bool IsGenericEnumerable(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
        }

        public static GenericFamilyExpression LifecycleIs(this GenericFamilyExpression instance, ServiceLifetime lifetime)
        {
            // TODO: Verify that the lifetimes are correct. Especially the scoped one.

            switch (lifetime)
            {
                case ServiceLifetime.Singleton:
                    return instance.LifecycleIs(Lifecycles.Singleton);
                case ServiceLifetime.Scoped:
                    return instance.LifecycleIs(Lifecycles.Transient);
                case ServiceLifetime.Transient:
                    return instance.LifecycleIs(Lifecycles.Unique);
                default:
                    throw new ArgumentOutOfRangeException(nameof(lifetime), lifetime, null);
            }
        }
    }
}