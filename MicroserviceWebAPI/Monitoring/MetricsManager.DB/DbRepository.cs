using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Entities;
using Microsoft.EntityFrameworkCore;

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
        public Task<TEntity> GetById(int id)
        {
            return _context.Set<TEntity>().Where(x => x.Id == id).SingleAsync();
        }

        /// <inheritdoc />
        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
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