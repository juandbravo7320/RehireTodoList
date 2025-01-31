using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Repository;
using ToDoList.Domain.Users;

namespace ToDoList.Infrastructure.Repository;

public class UserPermissionRepository(ApplicationDbContext dbContext) : IUserPermissionRepository
{
    private readonly DbSet<UserPermission> _dbSet = dbContext.Set<UserPermission>();
    
    public async Task AddAsync(UserPermission userPermission)
    {
        await _dbSet.AddAsync(userPermission);
    }

    public async Task AddRangeAsync(IEnumerable<UserPermission> userPermissions)
    {
        await _dbSet.AddRangeAsync(userPermissions);
    }
}