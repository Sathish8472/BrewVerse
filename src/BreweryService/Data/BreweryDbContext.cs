using BreweryService.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryService.API.Data
{
    public class BreweryDbContext : DbContext
    {
        public BreweryDbContext(DbContextOptions<BreweryDbContext> options) : base(options)
        {
        }
        public DbSet<Brewery> Breweries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
