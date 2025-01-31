using ToDoList.Domain.Users;

namespace ToDoList.Domain.Repository;

public interface IUserPermissionRepository
{
    Task AddAsync(UserPermission userPermission);
    Task AddRangeAsync(IEnumerable<UserPermission> userPermissions);
    void RemoveRange(IEnumerable<UserPermission> userPermissions);
    Task<bool> HasPermissionAsync(Guid userId, Guid permissionId);
}