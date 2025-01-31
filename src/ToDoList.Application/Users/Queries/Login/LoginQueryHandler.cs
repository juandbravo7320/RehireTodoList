using Microsoft.AspNetCore.Identity;
using ToDoList.Application.Abstractions.Authentication;
using ToDoList.Application.Abstractions.Messaging;
using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Repository;
using ToDoList.Domain.Users;

namespace ToDoList.Application.Users.Queries.Login;

public class LoginQueryHandler(
    IUserRepository userRepository,
    IRoleRepository roleRepository,
    IPasswordHasher<User> passwordHasher,
    IAuthenticationService authenticationService) : IQueryHandler<LoginQuery, LoginResponse>
{
    public async Task<Result<LoginResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindByEmailAsync(request.Email);

        if (user is null)
            return Result.Failure<LoginResponse>(UserErrors.IncorrectCredentials);
        
        var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
        
        if (passwordVerificationResult == PasswordVerificationResult.Failed)
            return Result.Failure<LoginResponse>(UserErrors.IncorrectCredentials);
        
        var role = await roleRepository.FindByIdAsync(user.RoleId);
        
        if (role is null)
            return Result.Failure<LoginResponse>(UserErrors.RoleNotFound);

        var token = authenticationService.GenerateAccessToken(user, role);
        
        return Result.Success(
            new LoginResponse(
                user.FirstName,
                user.LastName,
                user.Email,
                token
            ));
    }
}