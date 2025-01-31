using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Repository;
using ToDoList.Domain.Users;

namespace ToDoList.Infrastructure.Repository;

public class RoleRepository(ApplicationDbContext dbContext) : GenericRepository<Role, Guid>(dbContext), IRoleRepository
{
    public async Task<List<Permission>> GetPermissionsByRoleAsync(Guid roleId)
    {
        return await _dbSet.Where(x => x.Id == roleId)
            .SelectMany(x => x.RolePermissions)
            .Select(rp => rp.Permission)
            .ToListAsync();
    }
}