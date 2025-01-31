using ToDoList.Application.Abstractions.Authorization;
using ToDoList.Domain.Repository;

namespace ToDoList.Infrastructure.Authorization;

public class PermissionService(IUserPermissionRepository userPermissionRepository) : IPermissionService
{
    public async Task<bool> HasPermissionAsync(Guid userId, Guid permissionId)
    {
        return await userPermissionRepository.HasPermissionAsync(userId, permissionId);
    }
}