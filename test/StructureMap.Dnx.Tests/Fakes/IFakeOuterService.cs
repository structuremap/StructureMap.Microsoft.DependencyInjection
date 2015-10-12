namespace StructureMap.Dnx.Tests.Fakes
{
    internal interface IFakeOuterService
    {
        void Interrogate(out string singleValue, out string[] multipleValues);
    }
}