using TaskStatus = ToDoList.Domain.Tasks.TaskStatus;

namespace ToDoList.Application.Tasks.Queries.ListTasks;

public record TaskResponse(
    Guid Id,
    string Description,
    TaskStatus Status,
    DateTime CreatedAtUtc);