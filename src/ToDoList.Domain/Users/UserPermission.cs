using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Users;

public sealed class UserPermission : Audit
{
    public Guid UserId { get; private set; }
    public User User { get; }
    public Guid PermissionId { get; private set; }
    public User Permission { get; }
    
    public UserPermission(
        Guid userId,
        Guid permissionId)
    {
        UserId = userId;
        PermissionId = permissionId;
    }
    
    public UserPermission Create(
        Guid userId,
        Guid permissionId)
    {
        return new UserPermission(
            userId,
            permissionId);
    }
}