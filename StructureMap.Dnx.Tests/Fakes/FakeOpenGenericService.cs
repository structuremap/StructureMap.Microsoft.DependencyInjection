namespace StructureMap.Dnx.Tests.Fakes
{
    public class FakeOpenGenericService<T> : IFakeOpenGenericService<T>
    {
        private readonly T _otherService;

        public FakeOpenGenericService(T otherService)
        {
            _otherService = otherService;
        }

        public T SimpleMethod()
        {
            return _otherService;
        }
    }
}