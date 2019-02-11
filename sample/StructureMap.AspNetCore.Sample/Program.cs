using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace StructureMap.AspNetCore.Sample
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStructureMap() // Add support for StructureMap
                .UseStartup<Startup>();
    }
}
