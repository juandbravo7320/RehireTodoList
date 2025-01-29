namespace ToDoList.Domain.Abstractions;

public abstract class Entity : Audit
{
    public Guid Id { get; init; }
    
    protected Entity(Guid id)
    {
        Id = id;
    }
}