using ToDoList.Domain.Repository;
using Task = ToDoList.Domain.Tasks.Task;

namespace ToDoList.Infrastructure.Repository;

public class TaskRepository(ApplicationDbContext dbContext) : GenericRepository<Task, Guid>(dbContext), ITaskRepository
{
    
}