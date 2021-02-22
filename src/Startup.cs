using ImageRandomizer.ApiClients;
using ImageRandomizer.Extensions;
using ImageRandomizer.Options;
using ImageRandomizer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ImageRandomizer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ImgurClientOptions>(Configuration.GetSection("ImgurClientOptions"));
            services.Configure<ImageCachingHostedServiceOptions>(Configuration.GetSection("ImageCachingHostedServiceOptions"));
            services.ConfigureImgurClient<IGalleryClient>();

            services.AddScoped<IImgurImageDownloadService, ImgurImageDownloadService>();
            
            services.AddSingleton<ImgurImageCache>();
            services.AddHostedService<ImgurImageCachingHostedService>();

            services.AddHealthChecks();

            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "ImageRandomizer", Version = "v1" }); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ImageRandomizer v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/hc/live");
                endpoints.MapHealthChecks("/hc/ready");
            });
        }
    }
}