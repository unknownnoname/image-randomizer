using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ImageRandomizer.Services
{
    public interface IImgurImageDownloadService
    {
        Task<byte[]> DownloadAsync(string url);
    }
    
    internal class ImgurImageDownloadService : IImgurImageDownloadService
    {
        private readonly ILogger<Startup>  _logger;

        public ImgurImageDownloadService(ILogger<Startup> logger)
        {
            _logger = logger;
        }
        
        public async Task<byte[]> DownloadAsync(string url)
        {
            using WebClient webClient = new WebClient();

            await using Stream stream = await webClient.OpenReadTaskAsync(url);
            
            var img = Image.FromStream(stream);
            var path = $"/data/images/{Guid.NewGuid().ToString()}.{GetImageExtension(img)}";
            img.Save(path, img.RawFormat);

            _logger.LogInformation($"Saving image to {path}");

            return await File.ReadAllBytesAsync(path);
        }

        private string GetImageExtension(Image image)
        {
            return Equals(image.RawFormat, ImageFormat.Png) ? "png" : "jpg";
        }
    }
}