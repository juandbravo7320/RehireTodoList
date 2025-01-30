using ToDoList.Application.Abstractions.Messaging;
using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Repository;
using ToDoList.Domain.Users;

namespace ToDoList.Application.Users.Commands.UpdateUser;

public sealed class UpdateUserCommandHandler(
    IUnitOfWork unitOfWork,
    IUserRepository userRepository,
    IRoleRepository roleRepository) : ICommandHandler<UpdateUserCommand>
{
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindByIdAsync(request.Id);
        
        if (user is null) return Result.Failure(UserErrors.NotFound);
        
        var role = await roleRepository.FindByIdAsync(request.RoleId);
        
        if (role is null) return Result.Failure(UserErrors.RoleNotFound);

        user.Update(request.FirstName, request.LastName, request.Username, request.RoleId);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}