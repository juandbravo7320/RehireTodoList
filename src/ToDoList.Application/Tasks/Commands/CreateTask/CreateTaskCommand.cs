using ToDoList.Application.Abstractions.Messaging;

namespace ToDoList.Application.Tasks.Commands.CreateTask;

public record CreateTaskCommand(
    string Description) : ICommand<Guid>;