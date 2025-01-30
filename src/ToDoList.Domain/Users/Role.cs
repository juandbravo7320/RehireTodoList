using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Users;

public sealed class Role : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    
    public ICollection<RolePermission> RolePermissions { get; }
    
    public Role(Guid id) : base(id)
    {
    }
    
    public Role(
        Guid id,
        string name,
        string description) : base(id)
    {
        Name = name;
        Description = description;
    }
    
    public Role Create(
        string name,
        string description)
    {
        return new Role(
            Guid.NewGuid(),
            name,
            description);
    }
    
    // Seed Data
    
    public static readonly Role Admin = new(
        Guid.Parse("d2b3fb32-95c1-4703-aec2-c98a36762138"),
        "Admin", 
        "Has full access to the application, including managing users, assigning roles, and performing all task-related actions (create, read, update, and delete). Admins can also configure system settings and oversee overall application functionality.");
        
    public static readonly Role Level2 = new(
        Guid.Parse("f55cbc28-01c4-427d-9a40-ed271472da7d"),
        "Level 2", 
        "Has advanced permissions, allowing them to create, read, update, and delete tasks. However, they do not have administrative privileges such as user management or system settings modification.");
        
    public static readonly Role Level1 = new(
        Guid.Parse("cce065f9-acb8-429d-8deb-3e75f7b1e2a0"),
        "Level 1",
        "Has basic permissions, typically limited to creating and reading their own tasks. Level 1 users do not have the ability to update or delete tasks, nor can they manage other users or system settings.");
}