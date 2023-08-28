using BarService.API.Data;
using BarService.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BarService.API.Config
{
    public static class ServicesConfig
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddDbContext<BarDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")); // Use SQLite database
            });

            services.AddTransient<IBarService, BarService.API.Services.BarService>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
