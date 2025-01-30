using ToDoList.Application.Abstractions.Messaging;
using TaskStatus = ToDoList.Domain.Tasks.TaskStatus;

namespace ToDoList.Application.Tasks.Commands.UpdateTask;

public record UpdateTaskCommand(
    Guid Id,
    string Description,
    TaskStatus Status) : ICommand;