using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Specification;
using Microsoft.Extensions.DependencyInjection.Specification.Fakes;
using StructureMap.Graph;
using Xunit;

namespace StructureMap.Microsoft.DependencyInjection.Tests
{
    public class StructureMapContainerTests : DependencyInjectionSpecificationTests
    {
        protected override IServiceProvider CreateServiceProvider(IServiceCollection services)
        {
            var container = new Container();

            container.Populate(services);

            return container.GetInstance<IServiceProvider>();
        }

        [Fact]
        public void PopulatingTheContainerMoreThanOnceThrows()
        {
            var services = new ServiceCollection();

            services.AddTransient<IFakeService, FakeService>();

            var container = new Container();

            container.Configure(config => config.Populate(services));

            Assert.Throws<InvalidOperationException>(() => container.Populate(services));
        }
    }
}
