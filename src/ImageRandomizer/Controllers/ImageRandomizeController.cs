using System.IO;
using System.Net;
using System.Threading.Tasks;
using ImageRandomizer.ApiClients.Responses;
using ImageRandomizer.Services;
using Microsoft.AspNetCore.Mvc;

namespace ImageRandomizer.Controllers
{
    [ApiController]
    [Route("api/image")]
    public class ImageRandomizeController : Controller
    {
        private readonly ImgurImageCache _imgurImageCache;
        private readonly IImgurImageDownloadService _downloadService;

        public ImageRandomizeController(ImgurImageCache imgurImageCache, IImgurImageDownloadService downloadService)
        {
            _imgurImageCache = imgurImageCache;
            _downloadService = downloadService;
        }
        
        [HttpGet("randomize")]
        public async Task<FileContentResult> RandomizeAsync()
        {
            var randomImage = await _imgurImageCache.DequeueAsync();

            var bytes = await _downloadService.DownloadAsync(randomImage.Link.ToString());

            return File(bytes, randomImage.Type);
        }
    }
}