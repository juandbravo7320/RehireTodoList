namespace ToDoList.Domain.Users;

public sealed class RolePermission 
{
    public Guid RoleId { get; }
    public Role Role { get; }
    public Guid PermissionId { get; }
    public Permission Permission { get; }
}