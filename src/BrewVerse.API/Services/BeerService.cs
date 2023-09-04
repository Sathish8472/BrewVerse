using BrewVerse.Abstractions.Dto;
using BrewVerse.Abstractions.Interfaces.Data;
using BrewVerse.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewVerse.API.Services
{
    public class BeerService : BaseService, IBeerService
    {
        private readonly IBeerDataService _beerDataService;

        public BeerService(IBeerDataService beerDataService)
        {
            _beerDataService = beerDataService;
        }

        public async Task<ApiResponseDto<IEnumerable<BeerDto>>> GetAllBeersAsync()
        {
            try
            {
                var response = await _beerDataService.GetAllBeersAsync();
                if (response == null)
                {
                    return GetErrorResponse<IEnumerable<BeerDto>>($"No Beers found", 404);
                }

                return GetSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return GetErrorResponse<IEnumerable<BeerDto>>($"Error occurred while fetching all the Beers, Exception => {ex}", 500);
            }
        }

        public async Task<ApiResponseDto<BeerDto>> GetBeerByIdAsync(int id)
        {
            var response = await _beerDataService.GetBeerByIdAsync(id);

            return GetSuccessResponse(response);
        }

        public async Task<ApiResponseDto<BeerDto>> CreateBeerAsync(BeerDto beer)
        {
            var response = await _beerDataService.CreateBeerAsync(beer);

            return GetSuccessResponse(response);
        }

        public async Task<ApiResponseDto<BeerDto>> UpdateBeerAsync(int id, BeerDto beer)
        {
            var response = await _beerDataService.UpdateBeerAsync(id, beer);

            return GetSuccessResponse(response);
        }

        public async Task<ApiResponseDto<bool>> DeleteBeerAsync(int id)
        {
            var response = await _beerDataService.DeleteBeerAsync(id);

            return GetSuccessResponse(response);
        }
    }
}
