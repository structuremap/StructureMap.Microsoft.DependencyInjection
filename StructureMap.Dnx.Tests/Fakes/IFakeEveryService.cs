namespace StructureMap.Dnx.Tests.Fakes
{
    internal interface IFakeEveryService :
        IFakeMultipleService,
        IFakeScopedService,
        IFakeServiceInstance,
        IFakeSingletonService,
        IFakeOpenGenericService<string>
    {
    }
}