namespace StructureMap.Dnx.Tests.Fakes
{
    internal interface IFakeOpenGenericService<out T>
    {
        T SimpleMethod();
    }
}