using Lokaverk.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace Lokaverk.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly OrderDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(OrderDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.CreatedDate = DateTime.Now;
                baseEntity.UpdatedDate = DateTime.Now;
            }
            await _entities.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _entities.FindAsync(id);
            _entities.Remove(entity);
        }

        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> condition)
        {
            return await _entities.FirstOrDefaultAsync(condition);
        }

        public async Task<T> FindByConditionWithIncludesAsync(
            Expression<Func<T, bool>> condition,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities;

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(condition);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.UpdatedDate = DateTime.Now;
            }
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
