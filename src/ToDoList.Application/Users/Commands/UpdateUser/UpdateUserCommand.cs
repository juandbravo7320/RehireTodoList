using ToDoList.Application.Abstractions.Messaging;

namespace ToDoList.Application.Users.Commands.UpdateUser;

public record UpdateUserCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Username,
    Guid RoleId) : ICommand;