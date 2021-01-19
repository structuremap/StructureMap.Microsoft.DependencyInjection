using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace StructureMap.AspNetCoreV2.Sample
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseStructureMap() // Add support for StructureMap
                .ConfigureContainer<Registry>((hostContext, container) =>
                {
                    // Use this method to add services, using StructureMap-specific APIs.
                    container.For<ILogger>().Use<ConsoleLogger>();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
