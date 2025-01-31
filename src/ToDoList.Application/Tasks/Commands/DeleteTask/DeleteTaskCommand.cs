using ToDoList.Application.Abstractions.Messaging;

namespace ToDoList.Application.Tasks.Commands.DeleteTask;

public record DeleteTaskCommand(Guid Id) : ICommand;