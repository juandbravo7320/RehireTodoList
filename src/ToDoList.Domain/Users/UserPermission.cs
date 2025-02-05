using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Users;

public sealed class UserPermission : Auditable
{
    public Guid UserId { get; private set; }
    public User User { get; }
    public Guid PermissionId { get; private set; }
    public Permission Permission { get; }
    
    public UserPermission()
    {
    }
    
    public UserPermission(
        Guid userId,
        Guid permissionId)
    {
        UserId = userId;
        PermissionId = permissionId;
    }
    
    public static UserPermission Create(
        Guid userId,
        Guid permissionId)
    {
        return new UserPermission(
            userId,
            permissionId);
    }
}