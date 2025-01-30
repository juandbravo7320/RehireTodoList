using ToDoList.Application.Abstractions.Messaging;
using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Repository;
using ToDoList.Domain.Tasks;

namespace ToDoList.Application.Tasks.Commands.UpdateTask;

public class UpdateTaskCommandHandler(
    IUnitOfWork unitOfWork,
    ITaskRepository taskRepository) : ICommandHandler<UpdateTaskCommand>
{
    public async Task<Result> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await taskRepository.FindByIdAsync(request.Id);
        
        if (task is null) return Result.Failure(TaskErrors.NotFound);
        
        task.Update(request.Description, request.Status);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}