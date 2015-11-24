using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

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
            container.Configure(config => config.AddRegistry(new ServiceCollectionRegistry(descriptors)));
        }
    }
}
