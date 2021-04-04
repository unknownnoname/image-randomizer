using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageUrlScraper.ApiClients;
using ImageUrlScraper.ApiClients.Responses;
using Newtonsoft.Json;

namespace ImageUrlScraper.Services
{
    public class UrlScrapingService
    {
        private readonly IGalleryClient _galleryClient;

        private static readonly IReadOnlyCollection<string> Queries = new List<string>
        {
            "cats", "meme", "reddit", "youtube", "trump"
        };
        
        private static readonly IReadOnlyCollection<string> ImageTypes = new List<string>
        {
            "image/png", "image/jpeg"
        };

        public UrlScrapingService(IGalleryClient galleryClient)
        {
            _galleryClient = galleryClient;
        }
        
        public async Task DoWorkAsync()
        {
            string randomQuery = Queries.OrderBy(_ => Guid.NewGuid()).FirstOrDefault();
            GalleriesResponse galleriesResponse = await _galleryClient.SearchGalleries(randomQuery);
            
            IEnumerable<ImgurImage> images = galleriesResponse.Data
                .Where(x => x.Images != null)
                .SelectMany(x => x.Images)
                .Where(x => ImageTypes.Contains(x.Type));

            string jsonImages = JsonConvert.SerializeObject(images);
            
            await File.WriteAllTextAsync("/data/images/scraped-images.json", jsonImages);
        }
    }
}