using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Abstractions.Authorization;
using ToDoList.Application.Abstractions.Messaging;
using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Repository;
using ToDoList.Domain.Users;

namespace ToDoList.Application.Users.Commands.UpdateUser;

public sealed class UpdateUserCommandHandler(
    IUnitOfWork unitOfWork,
    IUserRepository userRepository,
    IPermissionService permissionService,
    IPermissionRepository permissionRepository,
    IUserPermissionRepository userPermissionRepository) : ICommandHandler<UpdateUserCommand>
{
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindByIdAsync(request.Id);
        
        if (user is null) return Result.Failure(UserErrors.NotFound);
        
        var hasPermission = await permissionService.HasPermissionAsync(user.Id, Permission.ManageUsers.Id);
        
        if (!hasPermission) return Result.Failure(UserErrors.Unauthorized);
        
        var permissionsResult = await ValidatePermissions(request.Permissions);
        
        if (permissionsResult.IsFailure) return permissionsResult;

        user.Update(request.FirstName, request.LastName, request.Username);

        await UpdatePermissions(request, user);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }

    private async Task<Result> ValidatePermissions(List<Guid> permissionIds)
    {
        var permissions = await permissionRepository.Queryable()
            .Where(x => permissionIds.Contains(x.Id))
            .ToListAsync();
        
        var notFoundPermissions = permissionIds.Except(permissions.Select(x => x.Id)).ToList();
        
        return notFoundPermissions.Count != 0 
            ? Result.Failure(UserErrors.NotFoundPermissions(notFoundPermissions)) 
            : Result.Success();
    }
    
    private async Task UpdatePermissions(UpdateUserCommand request, User user)
    {
        var userPermissions = await userRepository.GetPermissionsByUserIdAsync(user.Id);
        
        var currentPermissionIds = userPermissions.Select(p => p.PermissionId);
        var newPermissionIds = request.Permissions;

        var permissionsToAdd = newPermissionIds.Except(currentPermissionIds)
            .Select(permissionId => UserPermission.Create(user.Id, permissionId));

        var permissionsToRemove = userPermissions
            .Where(p => !newPermissionIds.Contains(p.PermissionId));

        userPermissionRepository.RemoveRange(permissionsToRemove);
        await userPermissionRepository.AddRangeAsync(permissionsToAdd);
    }
}