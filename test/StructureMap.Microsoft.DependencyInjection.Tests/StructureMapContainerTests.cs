using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Specification;
using Microsoft.Extensions.DependencyInjection.Specification.Fakes;
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

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PopulatingTheContainerMoreThanOnceThrows(bool checkDuplicateCalls)
        {
            var services = new ServiceCollection();

            services.AddTransient<IFakeService, FakeService>();

            var container = new Container();

            container.Configure(config => config.Populate(services));

            if (checkDuplicateCalls)
            {
                Assert.Throws<InvalidOperationException>(() => container.Populate(services, checkDuplicateCalls));
            }
        }
    }
}
