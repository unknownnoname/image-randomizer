using System;
using System.Threading;
using System.Threading.Tasks;
using ImageRandomizer.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ImageRandomizer.Services
{
    public class ImgurImageCachingHostedService : BackgroundService 
    {
        private readonly ImgurImageCache _imgurImageCache;
        private readonly ImageCachingHostedServiceOptions _options;

        public ImgurImageCachingHostedService(IOptions<ImageCachingHostedServiceOptions> optionAccessor, ImgurImageCache imgurImageCache)
        {
            _imgurImageCache = imgurImageCache;
            _options = optionAccessor.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _imgurImageCache.RefillCache();

                await Task.Delay(TimeSpan.FromMinutes(_options.DelayMinutes), stoppingToken);
            }
        }
    }
}