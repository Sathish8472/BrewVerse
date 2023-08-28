using BarService.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BarService.API.Data
{
    public class BarDbContext : DbContext
    {
        public BarDbContext(DbContextOptions<BarDbContext> options) : base(options)
        {
        }

        public DbSet<Bar> Bars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
