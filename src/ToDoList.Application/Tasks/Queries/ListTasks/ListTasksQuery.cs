using ToDoList.Application.Abstractions.Messaging;
using ToDoList.Domain.Abstractions;
using TaskStatus = ToDoList.Domain.Tasks.TaskStatus;

namespace ToDoList.Application.Tasks.Queries.ListTasks;

public record ListTasks(
    string? Description,
    TaskStatus? Status,
    Page Page) : IQuery<Pageable<TaskResponse>>;