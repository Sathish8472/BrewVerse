using BreweryService.API.Data;
using BreweryService.API.Models;

namespace BreweryService.API.Services
{
    public class BreweryService : IBreweryService
    {
        private readonly BreweryDbContext _dbContext;

        public BreweryService(BreweryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Brewery AddBrewery(Brewery brewery)
        {
            _dbContext.Breweries.Add(brewery);
            _dbContext.SaveChanges();
            return brewery;
        }

        public Brewery GetBreweryById(int id)
        {
            return _dbContext.Breweries.Find(id);
        }

        public IEnumerable<Brewery> GetAllBreweries()
        {
            return _dbContext.Breweries.ToList();
        }

        public Brewery UpdateBrewery(Brewery brewery)
        {
            var existingBrewery = _dbContext.Breweries.Find(brewery.Id);
            if (existingBrewery == null)
            {
                return null;
            }

            existingBrewery.Name = brewery.Name;
            // Update other properties as needed

            _dbContext.SaveChanges();
            return existingBrewery;
        }

        public Brewery DeleteBrewery(int id)
        {
            var brewery = _dbContext.Breweries.Find(id);
            if (brewery == null)
            {
                return null;
            }

            _dbContext.Breweries.Remove(brewery);
            _dbContext.SaveChanges();
            return brewery;
        }
    }
}
