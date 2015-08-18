using System;
using Microsoft.Framework.DependencyInjection;
using StructureMap.Dnx.Tests.Fakes;
using Xunit;

namespace StructureMap.Dnx.Tests
{
    public class FactoryTests
    {
        [Fact]
        public void FactoryServiceAreCreatedAsPartOfObjectGraph()
        {
            // Arrange
            var container = new Container();

            container.Populate(TestServices.DefaultServices());

            var provider = container.GetInstance<IServiceProvider>();

            // Act
            var service1 = provider.GetService<ServiceAcceptingFactoryService>();
            var service2 = provider.GetService<ServiceAcceptingFactoryService>();

            // Assert
            Assert.Equal(42, service1.TransientService.Value);
            Assert.NotNull(service1.TransientService.FakeService);

            Assert.Equal(42, service2.TransientService.Value);
            Assert.NotNull(service2.TransientService.FakeService);

            Assert.NotNull(service1.ScopedService.FakeService);

            // Verify scoping works
            Assert.NotSame(service1.TransientService, service2.TransientService);
            Assert.Same(service1.ScopedService, service2.ScopedService);
        }
    }
}