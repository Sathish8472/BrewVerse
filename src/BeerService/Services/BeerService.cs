using BeerService.API.Data;
using BeerService.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerService.API.Services
{
    public class BeerService : IBeerService
    {
        private readonly BeerDbContext _dbContext;

        public BeerService(BeerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Beer> CreateBeerAsync(Beer beer)
        {
            _dbContext.Beers.Add(beer);
            await _dbContext.SaveChangesAsync();
            return beer;
        }

        public async Task<Beer> GetBeerByIdAsync(int id)
        {
            return await _dbContext.Beers.FindAsync(id);
        }

        public async Task<IEnumerable<Beer>> GetAllBeersAsync()
        {
            return await _dbContext.Beers.ToListAsync();
        }

        public async Task<Beer> UpdateBeerAsync(Beer beer)
        {
            var existingBeer = await _dbContext.Beers.FindAsync(beer.Id);
            if (existingBeer == null)
            {
                return null;
            }

            existingBeer.Name = beer.Name;
            existingBeer.PercentageAlcoholByVolume = beer.PercentageAlcoholByVolume;
            // Update other properties as needed

            await _dbContext.SaveChangesAsync();
            return existingBeer;
        }

        public async Task<Beer> DeleteBeerAsync(int id)
        {
            var beer = await _dbContext.Beers.FindAsync(id);
            if (beer == null)
            {
                return null;
            }

            _dbContext.Beers.Remove(beer);
            await _dbContext.SaveChangesAsync();
            return beer;
        }
    }
}
