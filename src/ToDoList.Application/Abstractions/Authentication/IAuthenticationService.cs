using ToDoList.Domain.Users;

namespace ToDoList.Application.Abstractions.Authentication;

public interface IAuthenticationService
{
    string GenerateAccessToken(User user, Role role);
}