using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TruckTest.Domain.Entities;
using TruckTest.Infrastructure.Context;

namespace TruckTest.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        TruckTestContext Context { get; }
        Task<List<T>> All(string includes = null);
        Task<T> GetById(int id, string includes = null);
        Task<bool> Any(Expression<Func<T, bool>> predicate);
        Task<int> Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task Commit(bool validate = true);
    }
}