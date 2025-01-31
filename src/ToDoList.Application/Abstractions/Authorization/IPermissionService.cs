namespace ToDoList.Application.Abstractions.Authorization;

public interface IPermissionService
{
    Task<bool> HasPermissionAsync(Guid userId, Guid permissionId);
}