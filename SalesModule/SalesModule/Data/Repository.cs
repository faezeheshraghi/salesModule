using Microsoft.EntityFrameworkCore;
using SaleModule.Models;
using SalesModule.Models;
using System.Linq.Expressions;

namespace SalesModule.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Int64 id)
        {
            return await _entities.FindAsync(id);
        }
        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public void Add(T entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            _entities.Add(entity);
        }
        public void Update(T entity)
        {
            entity.UpdateDate = DateTime.Now;
            _entities.Update(entity);
        }
        public async Task Delete(Int64 id)
        {
            var entity = await _entities.FindAsync(id);
            _entities.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }
    }
}
