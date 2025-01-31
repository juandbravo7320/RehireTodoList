using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Repository;
using ToDoList.Domain.Users;

namespace ToDoList.Infrastructure.Repository;

public class UserRepository(ApplicationDbContext dbContext) : GenericRepository<User, Guid>(dbContext), IUserRepository
{
    public async Task<bool> ExistWithSameEmailAsync(string email)
    {
        return await _dbSet.AnyAsync(u => u.Email == email);
    }
    
    public async Task<User?> FindByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<List<UserPermission>> GetPermissionsByUserIdAsync(Guid userId)
    {
        return await _dbSet.Where(x => x.Id == userId)
            .AsSplitQuery()
            .Include(x => x.UserPermissions)
            .SelectMany(x => x.UserPermissions)
            .ToListAsync();
    }
}