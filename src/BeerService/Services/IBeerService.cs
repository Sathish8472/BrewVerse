using BeerService.API.Models;

namespace BeerService.API.Services
{
    public interface IBeerService
    {
        Task<Beer> CreateBeerAsync(Beer beer);
        Task<Beer> GetBeerByIdAsync(int id);
        Task<IEnumerable<Beer>> GetAllBeersAsync();
        Task<Beer> UpdateBeerAsync(Beer beer);
        Task<Beer> DeleteBeerAsync(int id);
    }
}
