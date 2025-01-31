using Microsoft.AspNetCore.Identity;
using ToDoList.Application.Abstractions.Messaging;
using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Repository;
using ToDoList.Domain.Users;

namespace ToDoList.Application.Users.Commands.RegisterUser;

public sealed class RegisterUserCommandHandler(
    IUnitOfWork unitOfWork,
    IUserRepository userRepository,
    IRoleRepository roleRepository,
    IPasswordHasher<User> passwordHasher,
    IUserPermissionRepository userPermissionRepository) : ICommandHandler<RegisterUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var existUser = await userRepository.ExistWithSameEmailAsync(request.Email);
        
        if (existUser) return Result.Failure<Guid>(UserErrors.EmailAlreadyExist);
        
        var user = User.Create(
            request.FirstName,
            request.Lastname, 
            request.Email,
            request.Password,
            request.Username,
            Role.Level2.Id);
        
        var passwordHash = passwordHasher.HashPassword(user, request.Password);
        user.PasswordHash = passwordHash;

        var permissions = await roleRepository.GetPermissionsByRoleAsync(Role.Level2.Id);
        var userPermissions = permissions.Select(p =>
            UserPermission.Create(user.Id, p.Id));

        await userRepository.AddAsync(user);
        await userPermissionRepository.AddRangeAsync(userPermissions);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(user.Id);
    }
}