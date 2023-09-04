using BrewVerse.Abstractions.Dto;
using BrewVerse.Abstractions.Interfaces.Data;
using BrewVerse.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace BrewVerse.API.Services
{
    public class BarService : BaseService, IBarService
    {
        private readonly IBarDataService _barDataService;

        public BarService(IBarDataService barDataService)
        {
            _barDataService = barDataService;
        }

        public async Task<ApiResponseDto<IEnumerable<BarDto>>> GetAllBarsAsync()
        {
            try
            {
                var response = await _barDataService.GetAllBarsAsync(); ;
                if (response == null)
                {
                    return GetErrorResponse<IEnumerable<BarDto>>($"No Bars found", 404);
                }

                return GetSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return GetErrorResponse<IEnumerable<BarDto>>($"Error occured while fetching all the Bars, Exception => {ex}", 500);
            }
        }

        public async Task<ApiResponseDto<BarDto>> GetBarByIdAsync(int id)
        {
            var response = await _barDataService.GetBarByIdAsync(id);

            return GetSuccessResponse(response);
        }

        public async Task<ApiResponseDto<BarDto>> CreateBarAsync(BarDto bar)
        {
            var response = await _barDataService.CreateBarAsync(bar);

            return GetSuccessResponse(response);
        }

        public async Task<ApiResponseDto<BarDto>> UpdateBarAsync(int id, BarDto bar)
        {
            var response = await _barDataService.UpdateBarAsync(id, bar);

            return GetSuccessResponse(response);
        }

        public async Task<ApiResponseDto<bool>> DeleteBarAsync(int id)
        {
            var response = await _barDataService.DeleteBarAsync(id);

            return GetSuccessResponse(response);
        }
    }
}
