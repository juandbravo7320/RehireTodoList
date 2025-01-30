using ToDoList.Domain.Abstractions;
using Task = ToDoList.Domain.Tasks.Task;

namespace ToDoList.Domain.Repository;

public interface ITaskRepository : IGenericRepository<Task, Guid>
{
    
}