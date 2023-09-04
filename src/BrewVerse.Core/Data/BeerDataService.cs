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
    public class BeerDataService : IBeerDataService
    {
        private readonly BrewVerseDbContext _dbContext;

        public BeerDataService(BrewVerseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<BeerDto>> GetAllBeersAsync()
        {
            var list = await _dbContext.Beers
                .Select(x => GetBeerResponseDto(x))
                .ToListAsync();
            return list;
        }

        public async Task<BeerDto> GetBeerByIdAsync(long id)
        {
            var beer = await _dbContext.Beers.FindAsync(id);
            if (beer == null)
                return null;

            return GetBeerResponseDto(beer);
        }

        public async Task<BeerDto> CreateBeerAsync(BeerDto beerDto)
        {
            var beer = new Beer
            {
                Name = beerDto.Name,
                PercentageAlcoholByVolume = beerDto.PercentageAlcoholByVolume
            };

            _dbContext.Beers.Add(beer);
            await _dbContext.SaveChangesAsync();
            return GetBeerResponseDto(beer);
        }

        public async Task<BeerDto> UpdateBeerAsync(int id, BeerDto beerDto)
        {
            var beer = await _dbContext.Beers.FindAsync(id);
            if (beer == null)
                return null;

            beer.Name = beerDto.Name;
            beer.PercentageAlcoholByVolume = beerDto.PercentageAlcoholByVolume;

            await _dbContext.SaveChangesAsync();
            return await GetBeerByIdAsync(id);
        }

        public async Task<bool> DeleteBeerAsync(int id)
        {
            var existingBeer = await _dbContext.Beers.FindAsync(id);
            if (existingBeer == null)
                return false;

            _dbContext.Beers.Remove(existingBeer);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        #region Helpers

        public static BeerDto GetBeerResponseDto(Beer beer)
        {
            return new BeerDto
            {
                Name = beer.Name,
                PercentageAlcoholByVolume = beer.PercentageAlcoholByVolume,
                Id = beer.Id
            };
        }

        #endregion
    }
}
