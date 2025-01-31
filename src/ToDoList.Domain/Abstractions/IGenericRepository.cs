namespace ToDoList.Domain.Abstractions;

public interface IGenericRepository<T, TId> where T : Entity
{
    Task<T?> FindByIdAsync(TId id);
    
    Task AddAsync(T entity);

    IQueryable<T> Queryable();
}