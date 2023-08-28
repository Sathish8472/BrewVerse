using BeerService.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BeerService.API.Data
{
    public class BeerDbContext : DbContext
    {
        public BeerDbContext(DbContextOptions<BeerDbContext> options) : base(options)
        {
        }
        public DbSet<Beer> Beers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
