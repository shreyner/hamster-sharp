using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Entities;

namespace MetricsManager.DB
{
    public class DbRepository<TEntity> where TEntity : BaseEntity

    {
        private AppDbContext _context { get; set; }

        public DbRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        /// <inheritdoc />
        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        /// <inheritdoc />
        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Update(entity));
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Remove(entity));
            await _context.SaveChangesAsync();
        }
    }
}