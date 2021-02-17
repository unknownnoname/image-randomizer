using System.Net.Http.Headers;
using System.Threading.Tasks;
using ImageRandomizer.ApiClients.Responses;
using RestEase;

namespace ImageRandomizer.ApiClients
{
    [Header("Accept-Encoding", "application/json")]
    public interface IGalleryClient
    {
        [Header("Authorization", "Client-ID")]
        AuthenticationHeaderValue Authorization { get; set; }

        [Get("gallery/search/{sort}/{window}/{page}/")]
        Task<GalleriesResponse> SearchGalleries(
            [Query("q")] string q,
            [Path("sort")] string sort = "time",
            [Path("window")] string window = "all",
            [Path("page")] int page = 0,
            [Query("q_type")] string qType = "png");
    }
}