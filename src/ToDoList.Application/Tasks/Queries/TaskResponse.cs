using TaskStatus = ToDoList.Domain.Tasks.TaskStatus;

namespace ToDoList.Application.Tasks.Queries;

public record TaskResponse(
    Guid Id,
    string Description,
    TaskStatus Status,
    DateTime CreatedAtUtc);