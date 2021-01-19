namespace StructureMap.AspNetCoreV2.Sample
{
    public interface ILogger
    {
        void Info(string message, params object[] args);
    }
}