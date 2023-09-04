using BrewVerse.Abstractions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewVerse.Abstractions.Interfaces.Data
{
    public interface IBarDataService
    {
        Task<IEnumerable<BarDto>> GetAllBarsAsync();
        Task<BarDto> GetBarByIdAsync(long id);
        Task<BarDto> CreateBarAsync(BarDto barDto);
        Task<BarDto> UpdateBarAsync(int id, BarDto barDto);
        Task<bool> DeleteBarAsync(int id);
    }
}
