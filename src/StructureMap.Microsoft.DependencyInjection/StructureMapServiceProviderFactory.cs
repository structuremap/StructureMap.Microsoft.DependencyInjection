using System;
using Microsoft.Extensions.DependencyInjection;

namespace StructureMap
{
    public class StructureMapServiceProviderFactory : IServiceProviderFactory<Registry>
    {
        public StructureMapServiceProviderFactory(Registry registry)
        {
            Registry = registry;
        }

        private Registry Registry { get; }

        public Registry CreateBuilder(IServiceCollection services)
        {
            var registry = Registry ?? new Registry();

            registry.Populate(services);

            return registry;
        }

        public IServiceProvider CreateServiceProvider(Registry registry)
        {
            var container = new Container(registry);

            return new StructureMapServiceProvider(container);
        }
    }


    public class StructureMapContainerServiceProviderFactory : IServiceProviderFactory<IContainer>
    {
        public StructureMapContainerServiceProviderFactory(IContainer container)
        {
            Container = container;
        }

        private IContainer Container { get; }

        public IContainer CreateBuilder(IServiceCollection services)
        {
            var container = Container ?? new Container();

            container.Populate(services);

            return container;
        }

        public IServiceProvider CreateServiceProvider(IContainer container)
        {
            return new StructureMapServiceProvider(container);
        }
    }
}