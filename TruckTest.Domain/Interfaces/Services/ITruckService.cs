using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TruckTest.Domain.Entities;

namespace TruckTest.Domain.Interfaces.Services
{
    public interface ITruckService
    {
        Task<IEnumerable<Truck>> GetAllAsync();
        Task<Truck> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(Truck truck);
        Task<int> AddAsync(Truck truck);
    }
}
