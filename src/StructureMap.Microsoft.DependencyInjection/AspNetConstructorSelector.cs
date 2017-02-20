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
        public ConstructorInfo Find(Type pluggedType, DependencyCollection dependencies, PluginGraph graph) =>
            pluggedType.GetTypeInfo()
                .DeclaredConstructors
                .Select(ctor => new { Constructor = ctor, Parameters = ctor.GetParameters() })
                .Where(x => x.Parameters.All(param => graph.HasFamily(param.ParameterType) || dependencies.Any(dep => dep.Type == param.ParameterType)))
                .OrderByDescending(x => x.Parameters.Length)
                .Select(x => x.Constructor)
                .FirstOrDefault();
    }
}
