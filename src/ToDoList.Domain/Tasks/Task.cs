using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Users;

namespace ToDoList.Domain.Tasks;

public class Task : Entity
{
    public string Description { get; set; }
    public TaskStatus Status { get; set; }
    public Guid OwnerId { get; private set; }
    public User Owner { get; }

    public Task(
        Guid id,
        string description,
        TaskStatus status,
        Guid ownerId) : base(id)
    {
        Description = description;
        Status = status;
        OwnerId = ownerId;
    }
    
    public Task Create(
        string description,
        Guid ownerId)
    {
        return new Task(
            Guid.NewGuid(),
            description,
            TaskStatus.Open,
            ownerId);
    }
}