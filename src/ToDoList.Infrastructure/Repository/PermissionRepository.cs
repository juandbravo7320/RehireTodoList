using ToDoList.Domain.Repository;
using ToDoList.Domain.Users;

namespace ToDoList.Infrastructure.Repository;

public class PermissionRepository(ApplicationDbContext dbContext) : GenericRepository<Permission, Guid>(dbContext), IPermissionRepository
{
    
}