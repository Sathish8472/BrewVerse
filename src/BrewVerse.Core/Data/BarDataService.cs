using BrewVerse.Abstractions.Dto;
using BrewVerse.Abstractions.Interfaces.Data;
using BrewVerse.API.Models;
using BrewVerse.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewVerse.Core.Data
{
    public class BarDataService : IBarDataService
    {
        private readonly BrewVerseDbContext _dbContext;

        public BarDataService(BrewVerseDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<IEnumerable<BarDto>> GetAllBarsAsync()
        {
            var list = await _dbContext.Bars
                                       .Select(x => GetBarResponseDto(x))
                                       .ToListAsync();
            return list;
        }

        public async Task<BarDto> GetBarByIdAsync(long id)
        {
            var bar = await _dbContext.Bars.FindAsync(id);
            if (bar == null)
                return null;

            return GetBarResponseDto(bar);
        }

        public async Task<BarDto> CreateBarAsync(BarDto barDto)
        {
            var bar = new Bar
            {
                Name = barDto.Name,
                Address = barDto.Address
            };

            _dbContext.Bars.Add(bar);
            await _dbContext.SaveChangesAsync();
            return GetBarResponseDto(bar);
        }

        public async Task<BarDto> UpdateBarAsync(int id, BarDto barDto)
        {
            var bar = await _dbContext.Bars.FindAsync(id);
            if (bar == null)
                return null;

            bar.Name = barDto.Name;
            bar.Address = barDto.Address;

            await _dbContext.SaveChangesAsync();
            return await GetBarByIdAsync(id);
        }

        public async Task<bool> DeleteBarAsync(int id)
        {
            var existingBar = await _dbContext.Bars.FindAsync(id);
            if (existingBar == null)
                return false;

            _dbContext.Bars.Remove(existingBar);
            await _dbContext.SaveChangesAsync();

            return true;
        }



        #region Helpers

        public static BarDto GetBarResponseDto(Bar bar)
        {
            return new BarDto
            {
                Name = bar.Name,
                Address = bar.Address,
                Id = bar.Id
            };
        }

        #endregion
    }
}
