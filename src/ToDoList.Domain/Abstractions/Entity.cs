namespace ToDoList.Domain.Abstractions;

public abstract class Entity : Auditable
{
    public Guid Id { get; init; }
    
    protected Entity()
    {
    }
    
    protected Entity(Guid id)
    {
        Id = id;
    }
}