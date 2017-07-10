using System;
using Microsoft.Extensions.DependencyInjection;
using StructureMap.Graph;

namespace StructureMap
{
    public class StructureMapServiceProviderFactory : IServiceProviderFactory<IRegistry>
    {
        public StructureMapServiceProviderFactory(IRegistry registry)
        {
            Registry = registry;
        }

        private IRegistry Registry { get; }

        public IRegistry CreateBuilder(IServiceCollection services)
        {
            var registry = Registry ?? new Registry();

            registry.Populate(services);

            return registry;
        }

        public IServiceProvider CreateServiceProvider(IRegistry registry)
        {
            var container = new Container(registry);

            return new StructureMapServiceProvider(container);
        }
    }
}