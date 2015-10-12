using System;
using Microsoft.Framework.DependencyInjection.Tests;
using Microsoft.Framework.DependencyInjection.Tests.Fakes;
using StructureMap.Pipeline;

namespace StructureMap.Dnx.Tests
{
    public class StructureMapContainerTests : ScopingContainerTestBase
    {
        protected override IServiceProvider CreateContainer()
        {
            var container = new Container(x => x.TransientTracking = TransientTracking.ExplicitReleaseMode);

            container.Populate(TestServices.DefaultServices());

            return container.GetInstance<IServiceProvider>();
        }
    }
}