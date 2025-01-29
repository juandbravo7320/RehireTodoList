using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Users;

public sealed class Role : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    
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
}