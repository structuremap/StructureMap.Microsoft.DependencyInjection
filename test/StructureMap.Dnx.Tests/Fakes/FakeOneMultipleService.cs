namespace StructureMap.Dnx.Tests.Fakes
{
    internal class FakeOneMultipleService : IFakeMultipleService
    {
        public string SimpleMethod()
        {
            return "FakeOneMultipleServiceAnotherMethod";
        }
    }
}