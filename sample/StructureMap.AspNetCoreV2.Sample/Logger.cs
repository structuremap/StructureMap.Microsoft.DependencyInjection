using System;

namespace StructureMap.AspNetCoreV2.Sample
{
    public class ConsoleLogger : ILogger
    {
        public void Info(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }
    }
}