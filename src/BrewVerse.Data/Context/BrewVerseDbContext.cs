using BrewVerse.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewVerse.Data.Context
{
    public class BrewVerseDbContext : DbContext
    {
        public BrewVerseDbContext(DbContextOptions<BrewVerseDbContext> options) : base(options)
        {

        }
        public DbSet<Bar> Bars { get; set; }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
