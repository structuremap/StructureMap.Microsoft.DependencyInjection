# StructureMap.Dnx

Adds DNX support for StructureMap

## Installation

> Install-Package StructureMap.Dnx

That's it! :grin::+1:

## Usage

The package contains a single, public extension method, `Populate`.
It's used to populate a StructureMap container using a set of `ServiceDescriptors` or an `IServiceCollection`.

### Example

```csharp
using System;
using Microsoft.Framework.DependencyInjection;
using StructureMap;

public class Startup
{
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddWhatever();

        var container = new Container();

        // Here we populate the container using the service collection.
        // This will register all services from the collection
        // into the container with the appropriate lifetime.
        container.Populate(services);

        // Make sure we return an IServiceProvider, 
        // this makes DNX use the StructureMap container.
        return container.GetInstance<IServiceProvider>();
    }
}
```
