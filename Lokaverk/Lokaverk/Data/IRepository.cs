using Lokaverk.Models;
using System.Linq.Expressions;

namespace Lokaverk.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> FindByConditionAsync(Expression<Func<T, bool>> condition);
        Task<T> FindByConditionWithIncludesAsync(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> SaveAsync();
    }
}
