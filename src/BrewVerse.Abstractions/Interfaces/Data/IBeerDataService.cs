using BrewVerse.Abstractions.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewVerse.Abstractions.Interfaces.Data
{
    public interface IBeerDataService
    {
        Task<IEnumerable<BeerDto>> GetAllBeersAsync();
        Task<BeerDto> GetBeerByIdAsync(long id);
        Task<BeerDto> CreateBeerAsync(BeerDto beerDto);
        Task<BeerDto> UpdateBeerAsync(int id, BeerDto beerDto);
        Task<bool> DeleteBeerAsync(int id);
    }
}
