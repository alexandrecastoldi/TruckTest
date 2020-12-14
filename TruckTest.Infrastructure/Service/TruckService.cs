using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckTest.Domain.Entities;
using TruckTest.Domain.Interfaces.Repositories;
using TruckTest.Domain.Interfaces.Services;

namespace TruckTest.Infrastructure.Service
{
    public class TruckService : ITruckService
    {
        protected readonly IBaseRepository<Truck> Repository;

        public TruckService(IBaseRepository<Truck> repository)
        {
            Repository = repository;
        }

        public virtual async Task<int> AddAsync(Truck model)
        {
            var truck = model;
            truck.LastUpdate = DateTime.Now.ToUniversalTime();
            return await Repository.Add(truck);
        }

        public virtual async Task DeleteAsync(int id)
        {
            await Repository.Delete(id);
        }

        public virtual async Task<IEnumerable<Truck>> GetAllAsync()
        {
            IEnumerable<Truck> trucks = await Repository.All();
            return trucks;
        }

        public virtual async Task<Truck> GetByIdAsync(int id)
        {
            var truck = await Repository.GetById(id);
            return truck;
        }
        public async Task<bool> IsActive(int id)
        {
            return await Repository.Any(x => x.Id == id);
        }

        public async Task UpdateAsync(Truck model)
        {
            var truck = model;
            truck.LastUpdate = DateTime.Now.ToUniversalTime();
            await Repository.Update(truck);
        }
    }
}
