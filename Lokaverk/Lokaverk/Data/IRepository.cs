using Lokaverk.Models;
using System.Linq.Expressions;

namespace Lokaverk.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> FindByConditionAsync(Expression<Func<T, bool>> condition);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> SaveAsync();
    }
}
