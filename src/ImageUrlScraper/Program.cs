using ImageUrlScraper.ApiClients;
using ImageUrlScraper.Extensions;
using ImageUrlScraper.Options;
using ImageUrlScraper.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ImageUrlScraper
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(builder =>
                {
                    builder.ClearProviders();
                    builder.AddConsole();
                })
                .ConfigureServices((_, services) =>
                {
                    var serviceProvider = services.BuildServiceProvider();
                    var configuration = serviceProvider.GetService<IConfiguration>();
                    
                    services.AddHostedService<CronJobService>();
                    
                    services.Configure<ImgurClientOptions>(configuration?.GetSection("ImgurClientOptions"));
                    services.ConfigureImgurClient<IGalleryClient>();

                    services.AddSingleton<UrlScrapingService>();
                });
    }
}