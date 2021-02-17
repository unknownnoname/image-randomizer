using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ImageRandomizer.Services
{
    public interface IImgurImageDownloadService
    {
        Task<byte[]> DownloadAsync(string url);
    }
    
    internal class ImgurImageDownloadService : IImgurImageDownloadService
    {
        public async Task<byte[]> DownloadAsync(string url)
        {
            using WebClient webClient = new WebClient();

            byte[] bytes;

            await using (Stream stream = await webClient.OpenReadTaskAsync(url))
            {
                bytes = StreamToByteArray(stream);
            }

            return bytes;
        }
        
        private static byte[] StreamToByteArray(Stream stream)
        {
            if (stream is MemoryStream memoryStream)
            {
                return memoryStream.ToArray();                
            }

            return ReadFully(stream);
        }
        
        private static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}