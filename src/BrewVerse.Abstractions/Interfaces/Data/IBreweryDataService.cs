using BrewVerse.Abstractions.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewVerse.Abstractions.Interfaces.Data
{
    public interface IBreweryDataService
    {
        Task<IEnumerable<BreweryDto>> GetAllBreweriesAsync();
        Task<BreweryDto> GetBreweryByIdAsync(long id);
        Task<BreweryDto> CreateBreweryAsync(BreweryDto breweryDto);
        Task<BreweryDto> UpdateBreweryAsync(int id, BreweryDto breweryDto);
        Task<bool> DeleteBreweryAsync(int id);
    }
}
