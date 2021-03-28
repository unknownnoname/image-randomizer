using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageRandomizer.ApiClients;
using ImageRandomizer.ApiClients.Responses;

namespace ImageRandomizer.Services
{
    public class ImgurImageCache
    {
        private readonly IGalleryClient _galleryClient;
        private static readonly ConcurrentQueue<ImgurImage> Queue = new ();

        private static readonly IReadOnlyCollection<string> Queries = new List<string>
        {
            "cats", "meme", "reddit", "youtube", "trump"
        };
        
        private static readonly IReadOnlyCollection<string> ImageTypes = new List<string>
        {
            "image/png", "image/jpeg"
        };

        public ImgurImageCache(IGalleryClient galleryClient)
        {
            _galleryClient = galleryClient;
        }
        
        public async Task RefillCache()
        {
            if (!Queue.IsEmpty)
            {
                return;
            }

            string randomQuery = Queries.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            GalleriesResponse galleriesResponse = await _galleryClient.SearchGalleries(randomQuery);
            
            IEnumerable<ImgurImage> images = galleriesResponse.Data
                .Where(x => x.Images != null)
                .SelectMany(x => x.Images)
                .Where(x => ImageTypes.Contains(x.Type));

            foreach (var img in images)
            {
                Queue.Enqueue(img);
            }
        }

        public async Task<ImgurImage> DequeueAsync()
        {
            if (Queue.TryDequeue(out var image))
            {
                return image;
            }

            await RefillCache();

            return await DequeueAsync();
        }
    }
}