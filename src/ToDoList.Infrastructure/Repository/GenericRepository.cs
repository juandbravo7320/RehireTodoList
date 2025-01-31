using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Abstractions;

namespace ToDoList.Infrastructure.Repository;

public abstract class GenericRepository<T, TId>(ApplicationDbContext dbContext) : IGenericRepository<T, TId>
    where T : Entity
{
    protected readonly DbSet<T> _dbSet = dbContext.Set<T>();

    public async Task<T?> FindByIdAsync(TId id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }
    
    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
    
    public void DeleteRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }
    
    public IQueryable<T> Queryable()
    {
        return _dbSet.AsQueryable();
    }
}