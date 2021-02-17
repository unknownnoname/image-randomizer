using System.Net.Http.Headers;
using System.Threading.Tasks;
using ImageRandomizer.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RestEase.HttpClientFactory;

namespace ImageRandomizer.Extensions
{
    public static class ImgurApiExtensions
    {
        public static void ConfigureImgurClient<TClient>(this IServiceCollection services)
            where TClient : class
        {
            var serviceProvider = services.BuildServiceProvider();
            var imgurClientOptions = serviceProvider.GetService<IOptions<ImgurClientOptions>>();

            services.AddRestEaseClient<TClient>(imgurClientOptions?.Value.BaseAddress, requestModifier: (request, _) =>
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", imgurClientOptions?.Value.AccessToken);

                return Task.CompletedTask;
            });
        }
    }
}