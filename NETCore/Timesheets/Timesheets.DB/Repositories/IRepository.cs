using Timesheets.DB.Entities;

namespace Timesheets.DB;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetByIdAsync(long id);
    IQueryable<TEntity> GetAll();
    Task AddAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
}
