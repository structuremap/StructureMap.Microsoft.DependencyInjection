using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace StructureMap.AspNetCoreV2.Sample
{
    class Worker : BackgroundService
    {
        private readonly ILogger _logger;

        public Worker(ILogger logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.Info("Worker is starting.");
            stoppingToken.Register(() => _logger.Info("Worker is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.Info("Worker running at: {0}", DateTime.UtcNow);
                await Task.Delay(1000, stoppingToken);
            }

            _logger.Info("Worker background task is stopping.");
        }
    }
}
