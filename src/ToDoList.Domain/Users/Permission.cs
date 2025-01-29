using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Users;

public sealed class Permission : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    public Permission(Guid id) : base(id)
    {
    }
    
    public Permission(
        Guid id,
        string name,
        string description) : base(id)
    {
        Name = name;
        Description = description;
    }
}