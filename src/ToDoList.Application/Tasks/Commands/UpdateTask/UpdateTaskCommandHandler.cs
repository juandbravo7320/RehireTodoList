using ToDoList.Application.Abstractions.Authentication;
using ToDoList.Application.Abstractions.Authorization;
using ToDoList.Application.Abstractions.Messaging;
using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Repository;
using ToDoList.Domain.Tasks;
using ToDoList.Domain.Users;

namespace ToDoList.Application.Tasks.Commands.UpdateTask;

public class UpdateTaskCommandHandler(
    IUnitOfWork unitOfWork,
    IUserContext userContext,
    ITaskRepository taskRepository,
    IPermissionService permissionService) : ICommandHandler<UpdateTaskCommand>
{
    public async Task<Result> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.UserId;
        
        var task = await taskRepository.FindByIdAsync(request.Id);
        
        if (task is null)
            return Result.Failure(TaskErrors.NotFound);
        
        var hasPermission = await permissionService.HasPermissionAsync(userId, Permission.UpdateTask.Id);
        
        if (!hasPermission) return Result.Failure<Guid>(UserErrors.Unauthorized);
        
        if (userId != task.OwnerId)
            return Result.Failure(TaskErrors.NotOwner);
        
        task.Update(request.Description, request.Status);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}