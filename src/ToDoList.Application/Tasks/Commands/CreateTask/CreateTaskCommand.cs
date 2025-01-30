using ToDoList.Application.Abstractions.Messaging;

namespace ToDoList.Application.Tasks.Commands.CreateTask;

public record CreateTaskCommand(
    Guid UserId,
    string Description) : ICommand<Guid>;