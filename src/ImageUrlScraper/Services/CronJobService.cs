using System;
using System.Threading;
using System.Threading.Tasks;
using ImageUrlScraper.ApiClients;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ImageUrlScraper.Services
{
    public class CronJobService : IHostedService
    {
        private readonly IHostApplicationLifetime _lifetime;
        private readonly ILogger _logger;
        private readonly UrlScrapingService _urlScrapingService;

        public CronJobService(
            IHostApplicationLifetime lifetime,
            ILogger<CronJobService> logger,
            UrlScrapingService urlScrapingService)
        {
            _lifetime = lifetime ?? throw new ArgumentNullException(nameof(lifetime));
            _logger = logger;
            _urlScrapingService = urlScrapingService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.Run(async () =>
            {
                try
                {
                    _logger.LogInformation("Url scraping started.");

                    await _urlScrapingService.DoWorkAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                    
                    Environment.ExitCode = 1;
                }
                finally
                {
                    _lifetime.StopApplication();
                }
            }, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // This is called when program is stopping, possibly prematurely.
            // This can be used for cleanup.
            return Task.CompletedTask;
        }
    }
}