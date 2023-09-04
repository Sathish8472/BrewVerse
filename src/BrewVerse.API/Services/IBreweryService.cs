using BrewVerse.Abstractions.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewVerse.API.Services
{
    public interface IBreweryService
    {
        Task<ApiResponseDto<IEnumerable<BreweryDto>>> GetAllBreweriesAsync();
        Task<ApiResponseDto<BreweryDto>> GetBreweryByIdAsync(int id);
        Task<ApiResponseDto<BreweryDto>> CreateBreweryAsync(BreweryDto brewery);
        Task<ApiResponseDto<BreweryDto>> UpdateBreweryAsync(int id, BreweryDto brewery);
        Task<ApiResponseDto<bool>> DeleteBreweryAsync(int id);
    }
}
