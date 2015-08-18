namespace StructureMap.Dnx.Tests.Fakes
{
    internal class DependOnNonexistentService : IDependOnNonexistentService
    {
        public DependOnNonexistentService(INonexistentService nonExistentService)
        {
        }
    }
}