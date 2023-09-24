using SalesModule.Models;
using System.Linq.Expressions;

namespace SalesModule.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Int64 id);
        Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        Task Delete(Int64 id);
        Task<bool> SaveChangesAsync();
    }
    }
