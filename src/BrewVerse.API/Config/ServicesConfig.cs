using BrewVerse.Abstractions.Interfaces.Data;
using BrewVerse.API.Services;
using BrewVerse.Core.Data;
using BrewVerse.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BrewVerse.API.Config
{
    public static class ServicesConfig
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "BrewVerse.Api",
                    Version = "v1",
                });
            });

            services.AddDbContext<BrewVerseDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<IBarService, BarService>();
            services.AddTransient<IBeerDataService, BeerDataService>();
            services.AddTransient<IBreweryService, BreweryService>();

            services.AddScoped<IBarDataService, BarDataService>();
            services.AddScoped<IBeerDataService, BeerDataService>();
            services.AddScoped<IBreweryDataService, BreweryDataService>();
        }
    }
}
