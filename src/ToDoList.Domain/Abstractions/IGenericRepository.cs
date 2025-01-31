namespace ToDoList.Domain.Abstractions;

public interface IGenericRepository<T, TId> where T : Entity
{
    Task<T?> FindByIdAsync(TId id);
    
    Task AddAsync(T entity);
    
    void Delete(T entity);
    
    void DeleteRange(IEnumerable<T> entities);

    IQueryable<T> Queryable();
}