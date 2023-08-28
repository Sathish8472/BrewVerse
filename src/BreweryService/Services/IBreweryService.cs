using BreweryService.API.Models;

namespace BreweryService.API.Services
{
    public interface IBreweryService
    {
        Brewery AddBrewery(Brewery brewery);
        Brewery GetBreweryById(int id);
        IEnumerable<Brewery> GetAllBreweries();
        Brewery UpdateBrewery(Brewery brewery);
        Brewery DeleteBrewery(int id);
    }
}
