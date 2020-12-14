using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckTest.Domain.Dtos;
using TruckTest.Domain.Entities;
using TruckTest.Domain.Interfaces.Repositories;
using TruckTest.Domain.Interfaces.Services;

namespace TruckTest.Infrastructure.Service
{
    public class TruckService : ITruckService
    {
        protected readonly IBaseRepository<Truck> Repository;
        public IMapper Mapper { get; }

        public TruckService(IBaseRepository<Truck> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public virtual async Task<int> AddAsync(TruckDto dto)
        {
            var truck = Mapper.Map<Truck>(dto);
            truck.LastUpdate = DateTime.Now.ToUniversalTime();
            return await Repository.Add(truck);
        }

        public virtual async Task DeleteAsync(int id)
        {
            await Repository.Delete(id);
        }

        public virtual async Task<IEnumerable<TruckDto>> GetAllAsync()
        {
            var trucks = await Repository.All();
            return Mapper.Map<IEnumerable<TruckDto>>(trucks);
        }

        public virtual async Task<TruckDto> GetByIdAsync(int id)
        {
            var truck = await Repository.GetById(id);
            return Mapper.Map<TruckDto>(truck);
        }
        public async Task<bool> IsActive(int id)
        {
            return await Repository.Any(x => x.Id == id);
        }

        public async Task UpdateAsync(TruckDto dto)
        {
            var truck = Mapper.Map<Truck>(dto);
            truck.LastUpdate = DateTime.Now.ToUniversalTime();
            await Repository.Update(truck);
        }
    }
}
