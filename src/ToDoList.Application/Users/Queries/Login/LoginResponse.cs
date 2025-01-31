namespace ToDoList.Application.Users.Queries.Login;

public record LoginResponse(
    string FirstName,
    string LastName,
    string Email,
    string Token);