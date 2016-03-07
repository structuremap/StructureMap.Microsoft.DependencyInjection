using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using StructureMap.Graph;
using StructureMap.Pipeline;

namespace StructureMap
{
    public static class ContainerExtensions
    {
        /// <summary>
        /// Populates the container using the specified service descriptors.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="descriptors">The service descriptors.</param>
        public static void Populate(this IContainer container, IEnumerable<ServiceDescriptor> descriptors)
        {
            container.Configure(config =>
            {
                config.Policies.ConstructorSelector<AspNetConstructorSelector>();
                config.AddRegistry(new ServiceCollectionRegistry(descriptors));
            });
        }

        private class AspNetConstructorSelector : IConstructorSelector
        {
            public ConstructorInfo Find(Type pluggedType, DependencyCollection dependencies, PluginGraph graph)
            {
                return pluggedType.GetTypeInfo()
                    .DeclaredConstructors
                    .Select(ctor => Tuple.Create(ctor, ctor.GetParameters()))
                    .Where(tuple => tuple.Item2.All(param => graph.HasFamily(param.ParameterType)))
                    .OrderByDescending(tuple => tuple.Item2.Length)
                    .Select(tuple => tuple.Item1)
                    .FirstOrDefault();
            }
        }
    }
}
