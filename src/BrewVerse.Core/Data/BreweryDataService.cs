using BrewVerse.Abstractions.Dto;
using BrewVerse.Abstractions.Interfaces.Data;
using BrewVerse.API.Models;
using BrewVerse.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewVerse.Core.Data
{
    public class BreweryDataService : IBreweryDataService
    {
        private readonly BrewVerseDbContext _dbContext;

        public BreweryDataService(BrewVerseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<BreweryDto>> GetAllBreweriesAsync()
        {
            var list = await _dbContext.Breweries
                .Select(x => GetBreweryResponseDto(x))
                .ToListAsync();

            return list;
        }

        public async Task<BreweryDto> GetBreweryByIdAsync(long id)
        {
            var brewery = await _dbContext.Breweries.FindAsync(id);
            if (brewery == null)
                return null;

            return GetBreweryResponseDto(brewery);
        }

        public async Task<BreweryDto> CreateBreweryAsync(BreweryDto breweryDto)
        {
            var brewery = new Brewery
            {
                Name = breweryDto.Name
            };

            _dbContext.Breweries.Add(brewery);
            await _dbContext.SaveChangesAsync();
            return GetBreweryResponseDto(brewery);
        }

        public async Task<BreweryDto> UpdateBreweryAsync(int id, BreweryDto breweryDto)
        {
            var brewery = await _dbContext.Breweries.FindAsync(id);
            if (brewery == null)
                return null;

            brewery.Name = breweryDto.Name;

            await _dbContext.SaveChangesAsync();
            return await GetBreweryByIdAsync(id);
        }

        public async Task<bool> DeleteBreweryAsync(int id)
        {
            var existingBrewery = await _dbContext.Breweries.FindAsync(id);
            if (existingBrewery == null)
                return false;

            _dbContext.Breweries.Remove(existingBrewery);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        #region Helpers

        public static BreweryDto GetBreweryResponseDto(Brewery brewery)
        {
            return new BreweryDto
            {
                Name = brewery.Name,
                Id = brewery.Id
            };
        }

        #endregion
    }
}
