using Microsoft.Extensions.DependencyInjection;

namespace StructureMap
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStructureMap(this IServiceCollection services)
        {
            return AddStructureMap(services, registry: null);
        }

        public static IServiceCollection AddStructureMap(this IServiceCollection services, Registry registry)
        {
            return services.AddSingleton<IServiceProviderFactory<Registry>>(new StructureMapServiceProviderFactory(registry));
        }

        public static IServiceCollection AddStructureMap(this IServiceCollection services, IContainer container)
        {
            return services.AddSingleton<IServiceProviderFactory<IContainer>>(new StructureMapContainerServiceProviderFactory(container));
        }
    }
}