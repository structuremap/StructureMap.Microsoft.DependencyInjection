using Microsoft.Extensions.DependencyInjection;

namespace StructureMap.Dnx.Tests.Internal
{
    public static class ServicesFactory
    {
        public static IServiceCollection GetServiceCollection()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IInternalService, InternalService>();

            return serviceCollection;
        }
    }
}