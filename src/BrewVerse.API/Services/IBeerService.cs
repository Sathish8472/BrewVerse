using BrewVerse.Abstractions.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewVerse.API.Services
{
    public interface IBeerService
    {
        Task<ApiResponseDto<IEnumerable<BeerDto>>> GetAllBeersAsync();
        Task<ApiResponseDto<BeerDto>> GetBeerByIdAsync(int id);
        Task<ApiResponseDto<BeerDto>> CreateBeerAsync(BeerDto beer);
        Task<ApiResponseDto<BeerDto>> UpdateBeerAsync(int id, BeerDto beer);
        Task<ApiResponseDto<bool>> DeleteBeerAsync(int id);
    }
}
