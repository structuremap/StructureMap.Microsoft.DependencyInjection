namespace StructureMap.Dnx.Tests.Fakes
{
    internal class ServiceAcceptingFactoryService
    {
        public ServiceAcceptingFactoryService(ScopedFactoryService scopedService, IFactoryService transientService)
        {
            ScopedService = scopedService;
            TransientService = transientService;
        }

        public ScopedFactoryService ScopedService { get; private set; }

        public IFactoryService TransientService { get; private set; }
    }
}