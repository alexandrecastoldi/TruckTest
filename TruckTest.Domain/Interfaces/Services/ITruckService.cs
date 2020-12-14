using System.Collections.Generic;
using System.Threading.Tasks;
using TruckTest.Domain.Dtos;

namespace TruckTest.Domain.Interfaces.Services
{
    public interface ITruckService
    {
        Task<IEnumerable<TruckDto>> GetAllAsync();
        Task<TruckDto> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(TruckDto truck);
        Task<int> AddAsync(TruckDto truck);
    }
}
