using ToDoList.Application.Abstractions.Messaging;

namespace ToDoList.Application.Users.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IQuery<LoginResponse>;