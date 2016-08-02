using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Extensions.DependencyInjection;
using StructureMap.Graph;
using StructureMap.Pipeline;

namespace StructureMap
{
    public static class ContainerExtensions
    {
        /// <summary>
        /// Populates the container using the specified service descriptors.
        /// </summary>
        /// <remarks>
        /// This method should only be called once per container.
        /// </remarks>
        /// <param name="container">The container.</param>
        /// <param name="descriptors">The service descriptors.</param>
        public static void Populate(this IContainer container, IEnumerable<ServiceDescriptor> descriptors)
        {
            container.Configure(config => config.Populate(descriptors));
        }

        /// <summary>
        /// Populates the container using the specified service descriptors.
        /// </summary>
        /// <remarks>
        /// This method should only be called once per container.
        /// </remarks>
        /// <param name="config">The configuration.</param>
        /// <param name="descriptors">The service descriptors.</param>
        public static void Populate(this ConfigurationExpression config, IEnumerable<ServiceDescriptor> descriptors)
        {
            // HACK: We insert this action in order to prevent Populate being called twice on the same container.
            config.Configure(ThrowIfMarkerInterfaceIsRegistered);

            config.For<IMarkerInterface>();

            config.Policies.ConstructorSelector<AspNetConstructorSelector>();

            config.For<IServiceProvider>()
                .LifecycleIs(Lifecycles.Container)
                .Use<StructureMapServiceProvider>();

            config.For<IServiceScopeFactory>()
                .LifecycleIs(Lifecycles.Container)
                .Use<StructureMapServiceScopeFactory>();

            config.Register(descriptors);
        }

        private static void ThrowIfMarkerInterfaceIsRegistered(PluginGraph graph)
        {
            if (graph.HasFamily<IMarkerInterface>())
            {
                throw new InvalidOperationException("Populate should only be called once per container.");
            }
        }

        private static void Register(this ConfigurationExpression config, IEnumerable<ServiceDescriptor> descriptors)
        {
            foreach (var descriptor in descriptors)
            {
                config.Register(descriptor);
            }
        }

        private static void Register(this ConfigurationExpression config, ServiceDescriptor descriptor)
        {
            if (descriptor.ImplementationType != null)
            {
                config.For(descriptor.ServiceType)
                    .LifecycleIs(descriptor.Lifetime)
                    .Use(descriptor.ImplementationType);

                return;
            }

            if (descriptor.ImplementationFactory != null)
            {
                config.For(descriptor.ServiceType)
                    .LifecycleIs(descriptor.Lifetime)
                    .Use(descriptor.CreateFactory());

                return;
            }

            config.For(descriptor.ServiceType)
                .LifecycleIs(descriptor.Lifetime)
                .Use(descriptor.ImplementationInstance);
        }

        private static Expression<Func<IContext, object>> CreateFactory(this ServiceDescriptor descriptor)
        {
            return context => descriptor.ImplementationFactory(context.GetInstance<IServiceProvider>());
        }

        private interface IMarkerInterface { }
    }
}
