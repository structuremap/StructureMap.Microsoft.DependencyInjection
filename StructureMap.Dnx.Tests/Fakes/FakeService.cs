using System;

namespace StructureMap.Dnx.Tests.Fakes
{
    internal class FakeService : IFakeEveryService, IDisposable
    {
        public FakeService()
        {
            Message = "FakeServiceSimpleMethod";
        }

        public bool Disposed { get; private set; }

        public string Message { get; set; }

        public string SimpleMethod()
        {
            return Message;
        }

        public void Dispose()
        {
            Disposed = true;
        }
    }
}