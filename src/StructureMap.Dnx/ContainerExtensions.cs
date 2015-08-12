using System.Collections.Generic;
using Microsoft.Framework.DependencyInjection;

namespace StructureMap.Dnx
{
    public static class ContainerExtensions
    {
        public static void Populate(this IContainer container, IEnumerable<ServiceDescriptor> descriptors)
        {
            container.Configure(config => config.AddRegistry(new ServiceCollectionRegistry(descriptors)));
        }
    }
}
