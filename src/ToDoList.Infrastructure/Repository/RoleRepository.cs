using ToDoList.Domain.Repository;
using ToDoList.Domain.Users;

namespace ToDoList.Infrastructure.Repository;

public class RoleRepository(ApplicationDbContext dbContext) : GenericRepository<Role, Guid>(dbContext), IRoleRepository
{
    
}