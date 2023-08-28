using BarService.API.Data;
using BarService.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BarService.API.Services
{
    public class BarService : IBarService
    {
        private readonly BarDbContext _dbContext;

        public BarService(BarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Bar>> GetAllBarsAsync()
        {
            return await _dbContext.Bars.ToListAsync();
        }

        public async Task<Bar> GetBarByIdAsync(int id)
        {
            return await _dbContext.Bars.FindAsync(id);
        }

        public async Task<Bar> CreateBarAsync(Bar bar)
        {
            _dbContext.Bars.Add(bar);
            await _dbContext.SaveChangesAsync();
            return bar;
        }

        public async Task<Bar> UpdateBarAsync(int id, Bar bar)
        {
            var existingBar = await _dbContext.Bars.FindAsync(id);
            if (existingBar == null)
                return null;

            existingBar.Name = bar.Name;
            existingBar.Address = bar.Address;

            await _dbContext.SaveChangesAsync();
            return existingBar;
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
    }
}
