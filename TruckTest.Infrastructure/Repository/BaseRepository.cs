using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TruckTest.Domain.Entities;
using TruckTest.Domain.Interfaces.Repositories;
using TruckTest.Infrastructure.Context;

namespace TruckTest.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public TruckTestContext Context { get; }
        private readonly DbSet<T> _dbSet;

        public BaseRepository(TruckTestContext context)
        {
            Context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<int> Add(T entity)
        {
            entity.LastUpdate = DateTime.Now.ToUniversalTime();
            await _dbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<List<T>> All(string includes = null)
        {
            var query = _dbSet.AsQueryable();

            if (includes != null)
                query = SetQueryIncludes(includes);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task Commit(bool validate = true)
        {
            Context.ChangeTracker.AutoDetectChangesEnabled = validate;
            await Context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var persistedEntity = await Context.FindAsync<T>(id);
            if (persistedEntity == null)
            {
                throw new Exception("Not found");
            }
            _dbSet.Remove(persistedEntity);
            await Context.SaveChangesAsync();
        }

        public async Task<T> GetById(int id, string includes = null)
        {
            var query = SetQueryIncludes(includes);
            var entity = await query.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new Exception("Not found");
            }
            return entity;
        }

        public async Task Update(T entity)
        {
            var persistedEntity = await Context.FindAsync<T>(entity.Id);
            if (persistedEntity == null)
            {
                throw new Exception("Not found");
            }
            Context.Entry(persistedEntity).CurrentValues.SetValues(entity);
            persistedEntity.LastUpdate = DateTime.Now.ToUniversalTime();
            await Context.SaveChangesAsync();
        }

        private IQueryable<T> SetQueryIncludes(string includes)
        {
            var query = _dbSet.AsQueryable();
            if (includes == null) return query;
            foreach (var include in includes.Split(','))
            {
                query = query.Include(include.Trim());
            }

            return query;
        }
    }
}
