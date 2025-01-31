using ToDoList.Application.Abstractions.Authentication;
using ToDoList.Application.Abstractions.Authorization;
using ToDoList.Application.Abstractions.Messaging;
using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Repository;
using ToDoList.Domain.Tasks;
using ToDoList.Domain.Users;

namespace ToDoList.Application.Tasks.Commands.DeleteTask;

public class DeleteTaskCommandHandler(
    IUnitOfWork unitOfWork,
    IUserContext userContext,
    ITaskRepository taskRepository,
    IPermissionService permissionService) : ICommandHandler<DeleteTaskCommand>
{
    public async Task<Result> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.UserId;
        
        var hasPermission = await permissionService.HasPermissionAsync(userId, Permission.DeleteTask.Id);
        
        if (!hasPermission) return Result.Failure<Guid>(UserErrors.Unauthorized);

        var task = await taskRepository.FindByIdAsync(request.Id);

        if (task is null) return Result.Failure(TaskErrors.NotFound);
        
        taskRepository.Delete(task);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}