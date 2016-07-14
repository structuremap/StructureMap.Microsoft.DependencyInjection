using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Specification;

namespace StructureMap.Dnx.Tests
{
    public class StructureMapContainerTests : DependencyInjectionSpecificationTests
    {
        protected override IServiceProvider CreateServiceProvider(IServiceCollection serviceCollection)
        {
            var container = new Container();

            container.Populate(serviceCollection);

            return container.GetInstance<IServiceProvider>();
        }
    }
}
