using System;
using backend.Providers;
using backend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataProvider, DataProvider>();

            services.AddHttpClient(nameof(DataProvider), client =>
            {
                client.BaseAddress = new Uri("https://en.wikipedia.org/w/");
                client.Timeout = TimeSpan.FromSeconds(30);
            });

            services.AddScoped<IWikiDataService, WikiDataService>();
            services.AddScoped<IWordCountService, WordCountService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}