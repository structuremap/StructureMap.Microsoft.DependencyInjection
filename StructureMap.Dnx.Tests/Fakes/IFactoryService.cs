namespace StructureMap.Dnx.Tests.Fakes
{
    internal interface IFactoryService
    {
        IFakeService FakeService { get; }

        int Value { get; }
    }
}