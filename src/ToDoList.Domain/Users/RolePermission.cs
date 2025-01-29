using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Users;

public sealed class RolePermission : Auditable
{
    public Guid RoleId { get; }
    public Role Role { get; }
    public Guid PermissionId { get; }
    public Permission Permission { get; }
    
    public RolePermission(
        Guid roleId,
        Guid permissionId)
    {
        RoleId = roleId;
        PermissionId = permissionId;
    }
}