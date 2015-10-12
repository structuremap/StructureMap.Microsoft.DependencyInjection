namespace StructureMap.Dnx.Tests.Fakes
{
    internal class FakeTwoMultipleService : IFakeMultipleService
    {
        public string SimpleMethod()
        {
            return "FakeTwoMultipleServiceAnotherMethod";
        }
    }
}