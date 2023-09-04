using BrewVerse.Abstractions.Dto;

namespace BrewVerse.API.Services
{
    public interface IBarService
    {
        Task<ApiResponseDto<IEnumerable<BarDto>>> GetAllBarsAsync();
        Task<ApiResponseDto<BarDto>> GetBarByIdAsync(int id);
        Task<ApiResponseDto<BarDto>> CreateBarAsync(BarDto bar);
        Task<ApiResponseDto<BarDto>> UpdateBarAsync(int id, BarDto bar);
        Task<ApiResponseDto<bool>> DeleteBarAsync(int id);
    }
}
