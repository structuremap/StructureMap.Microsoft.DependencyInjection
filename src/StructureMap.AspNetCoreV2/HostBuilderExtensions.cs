using Microsoft.Extensions.Hosting;

namespace StructureMap.AspNetCoreV2
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder UseStructureMap(this IHostBuilder builder)
        {
            return UseStructureMap(builder, registry: null);
        }

        public static IHostBuilder UseStructureMap(this IHostBuilder builder, Registry registry)
        {
            return builder.UseServiceProviderFactory(new StructureMapServiceProviderFactory(registry));
        }
    }
}