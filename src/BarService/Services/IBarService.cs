using BarService.API.Models;

namespace BarService.API.Services
{
    public interface IBarService
    {
        Task<IEnumerable<Bar>> GetAllBarsAsync();
        Task<Bar> GetBarByIdAsync(int id);
        Task<Bar> CreateBarAsync(Bar bar);
        Task<Bar> UpdateBarAsync(int id, Bar bar);
        Task<bool> DeleteBarAsync(int id);
    }
}
