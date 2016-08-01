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
            container.Configure(config => config.Populate(descriptors));
        }

        /// <summary>
        /// Populates the container using the specified service descriptors.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="descriptors">The service descriptors.</param>
        public static void Populate(this ConfigurationExpression config, IEnumerable<ServiceDescriptor> descriptors)
        {
            config.Policies.ConstructorSelector<AspNetConstructorSelector>();
            config.AddRegistry(new ServiceCollectionRegistry(descriptors));
        }

        private class AspNetConstructorSelector : IConstructorSelector
        {
            // ASP.NET expects registered services to be considered when selecting a ctor, SM doesn't by default.
            public ConstructorInfo Find(Type pluggedType, DependencyCollection dependencies, PluginGraph graph) =>
                pluggedType.GetTypeInfo()
                    .DeclaredConstructors
                    .Select(ctor => new { Constructor = ctor, Parameters = ctor.GetParameters() })
                    .Where(x => x.Parameters.All(param => graph.HasFamily(param.ParameterType)))
                    .OrderByDescending(x => x.Parameters.Length)
                    .Select(x => x.Constructor)
                    .FirstOrDefault();
        }
    }
}
