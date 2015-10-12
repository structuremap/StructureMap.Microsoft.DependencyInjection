using System;
using Microsoft.Framework.DependencyInjection.Tests;
using Microsoft.Framework.DependencyInjection.Tests.Fakes;

namespace StructureMap.Dnx.Tests
{
    public class StructureMapContainerTests : ScopingContainerTestBase
    {
        protected override IServiceProvider CreateContainer()
        {
            var container = new Container();

            container.Populate(TestServices.DefaultServices());

            return container.GetInstance<IServiceProvider>();
        }
    }
}