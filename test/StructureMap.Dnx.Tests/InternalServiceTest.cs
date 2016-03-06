using StructureMap.Dnx.Tests.Internal;
using System;
using Xunit;

namespace StructureMap.Dnx.Tests
{
    public class InternalServiceTest
    {
        [Fact]
        public void CanGetInternalService()
        {
            var container = new Container();

            container.Populate(ServicesFactory.GetServiceCollection());

            var provider = container.GetInstance<IServiceProvider>();

            var internalService = provider.GetService(typeof(IInternalService));

            Assert.NotNull(internalService);
        }
    }
}