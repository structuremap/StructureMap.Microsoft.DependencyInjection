using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Extensions.DependencyInjection;
using StructureMap.Pipeline;

namespace StructureMap
{
    internal sealed class ServiceCollectionRegistry : Registry
    {
        public ServiceCollectionRegistry(IEnumerable<ServiceDescriptor> descriptors)
        {
            For<IServiceProvider>().LifecycleIs(Lifecycles.Container).Use<StructureMapServiceProvider>();
            For<IServiceScopeFactory>().LifecycleIs(Lifecycles.Container).Use<StructureMapServiceScopeFactory>();

            Register(descriptors);
        }

        private void Register(IEnumerable<ServiceDescriptor> descriptors)
        {
            foreach (var descriptor in descriptors)
            {
                Register(descriptor);
            }
        }

        private void Register(ServiceDescriptor descriptor)
        {
            if (descriptor.ImplementationType != null)
            {
                For(descriptor.ServiceType)
                    .LifecycleIs(descriptor.Lifetime)
                    .Use(descriptor.ImplementationType);

                return;
            }

            if (descriptor.ImplementationFactory != null)
            {
                For(descriptor.ServiceType)
                    .LifecycleIs(descriptor.Lifetime)
                    .Use(CreateFactory(descriptor));

                return;
            }

            For(descriptor.ServiceType)
                .LifecycleIs(descriptor.Lifetime)
                .Use(descriptor.ImplementationInstance);
        }

        private static Expression<Func<IContext, object>> CreateFactory(ServiceDescriptor descriptor)
        {
            return context => descriptor.ImplementationFactory(context.GetInstance<IServiceProvider>());
        }
    }
}