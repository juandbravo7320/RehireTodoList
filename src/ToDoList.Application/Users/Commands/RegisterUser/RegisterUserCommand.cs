using ToDoList.Application.Abstractions.Messaging;

namespace ToDoList.Application.Users.Commands.RegisterUser;

public record RegisterUserCommand(
    string FirstName,
    string Lastname,
    string Username,
    string Email,
    string Password) : ICommand<Guid>;