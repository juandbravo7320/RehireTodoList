using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Users;

namespace ToDoList.Domain.Repository;

public interface IRoleRepository : IGenericRepository<Role, Guid>
{
    
}