using BrewVerse.Abstractions.Dto;
using BrewVerse.Abstractions.Interfaces.Data;
using BrewVerse.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewVerse.API.Services
{
    public class BreweryService : BaseService, IBreweryService
    {
        private readonly IBreweryDataService _breweryDataService;

        public BreweryService(IBreweryDataService breweryDataService)
        {
            _breweryDataService = breweryDataService;
        }

        public async Task<ApiResponseDto<IEnumerable<BreweryDto>>> GetAllBreweriesAsync()
        {
            try
            {
                var response = await _breweryDataService.GetAllBreweriesAsync();
                if (response == null)
                {
                    return GetErrorResponse<IEnumerable<BreweryDto>>($"No Breweries found", 404);
                }

                return GetSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return GetErrorResponse<IEnumerable<BreweryDto>>($"Error occurred while fetching all the Breweries, Exception => {ex}", 500);
            }
        }

        public async Task<ApiResponseDto<BreweryDto>> GetBreweryByIdAsync(int id)
        {
            var response = await _breweryDataService.GetBreweryByIdAsync(id);

            return GetSuccessResponse(response);
        }

        public async Task<ApiResponseDto<BreweryDto>> CreateBreweryAsync(BreweryDto brewery)
        {
            var response = await _breweryDataService.CreateBreweryAsync(brewery);

            return GetSuccessResponse(response);
        }

        public async Task<ApiResponseDto<BreweryDto>> UpdateBreweryAsync(int id, BreweryDto brewery)
        {
            var response = await _breweryDataService.UpdateBreweryAsync(id, brewery);

            return GetSuccessResponse(response);
        }

        public async Task<ApiResponseDto<bool>> DeleteBreweryAsync(int id)
        {
            var response = await _breweryDataService.DeleteBreweryAsync(id);

            return GetSuccessResponse(response);
        }
    }
}
