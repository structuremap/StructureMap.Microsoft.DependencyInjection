using System;
using System.Linq;
using System.Reflection;
using StructureMap.Graph;
using StructureMap.Pipeline;

namespace StructureMap
{
    internal class AspNetConstructorSelector : IConstructorSelector
    {
        // ASP.NET expects registered services to be considered when selecting a ctor, SM doesn't by default.
        public ConstructorInfo Find(Type pluggedType, DependencyCollection dependencies, PluginGraph graph)
        {
            var constructors = from constructor in pluggedType.GetConstructors()
                               select new
                               {
                                   Constructor = constructor,
                                   Parameters  = constructor.GetParameters(),
                               };

            var satisfiable = from constructor in constructors
                              where constructor.Parameters.All(parameter => ParameterIsRegistered(parameter, dependencies, graph))
                              orderby constructor.Parameters.Length descending
                              select constructor.Constructor;

            return satisfiable.FirstOrDefault();
        }

        private static bool ParameterIsRegistered(ParameterInfo parameter, DependencyCollection dependencies, PluginGraph graph)
        {
            return graph.HasFamily(parameter.ParameterType) || dependencies.Any(dependency => dependency.Type == parameter.ParameterType);
        }
    }
}
