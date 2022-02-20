using Microsoft.EntityFrameworkCore;
using Timesheets.DB.Entities;

namespace Timesheets.DB;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly DbContext _context;
    
    public Repository(AppDbContext context)
    {
        this._context = context;
    }

    public async Task<T?> GetByIdAsync(long id)
    {
        return await this._context.FindAsync<T>(id);
    }

    public IQueryable<T> GetAll()
    {
        return this._context.Set<T>().AsQueryable();
    }

    public async Task AddAsync(T entity)
    {
        await this._context.AddAsync(entity);
        await this.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        this._context.Remove(entity);
        await this.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        this._context.Update(entity);
        await this.SaveChangesAsync();
    }

    protected async Task SaveChangesAsync()
    {
        await this._context.SaveChangesAsync();
    }
}