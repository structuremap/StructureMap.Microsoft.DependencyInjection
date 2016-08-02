# StructureMap.Microsoft.DependencyInjection [![Build status](https://ci.appveyor.com/api/projects/status/tpk77374afp3dk8v?svg=true)](https://ci.appveyor.com/project/khellang/structuremap-dnx)

(Formerly known as StructureMap.Dnx)

Adds StructureMap support for [Microsoft.Extensions.DependencyInjection](https://github.com/aspnet/DependencyInjection)

## Installation

Add `StructureMap.Microsoft.DependencyInjection` to your **project.json**:

```json
"dependencies": {
  "StructureMap.Microsoft.DependencyInjection": "<version>"
}
```

## Usage

The package contains a single, public extension method, `Populate`.
It's used to populate a StructureMap container using a set of `ServiceDescriptors` or an `IServiceCollection`.

### Example

```csharp
using System;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

public class Startup
{
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddWhatever();

        var container = new Container();
        
        // You can populate the container instance in one of two ways:
        
        // 1. Use StructureMap's `Configure` method and call
        //    `Populate` on the `ConfigurationExpression`.
        
        container.Configure(config =>
        {
            // Register stuff in container, using the StructureMap APIs...

            config.Populate(services);
        });
        
        // 2. Call `Populate` directly on the container instance.
        //    This will internally do a call to `Configure`.
        
        // Register stuff in container, using the StructureMap APIs...

        // Here we populate the container using the service collection.
        // This will register all services from the collection
        // into the container with the appropriate lifetime.
        container.Populate(services);

        // Finally, make sure we return an IServiceProvider. This makes
        // ASP.NET use the StructureMap container to resolve its services.
        return container.GetInstance<IServiceProvider>();
    }
}
```
