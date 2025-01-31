using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Users;

namespace ToDoList.Domain.Repository;

public interface IUserRepository : IGenericRepository<User, Guid>
{
    Task<bool> ExistWithSameEmailAsync(string email);
    
    Task<User?> FindByEmailAsync(string email);
}