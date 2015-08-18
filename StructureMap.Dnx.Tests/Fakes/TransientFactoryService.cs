namespace StructureMap.Dnx.Tests.Fakes
{
    internal class TransientFactoryService : IFactoryService
    {
        public IFakeService FakeService { get; set; }

        public int Value { get; set; }
    }
}