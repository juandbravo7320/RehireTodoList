using ToDoList.Application.Abstractions.Messaging;
using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Repository;
using ToDoList.Domain.Users;
using Task = ToDoList.Domain.Tasks.Task;

namespace ToDoList.Application.Tasks.Commands.CreateTask;

public class CreateTaskCommandHandler(
    IUnitOfWork unitOfWork,
    ITaskRepository taskRepository,
    IUserRepository userRepository) : ICommandHandler<CreateTaskCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindByIdAsync(request.UserId);
        
        if (user is null)
            return Result.Failure<Guid>(UserErrors.NotFound);
        
        var task = Task.Create(request.Description, user.Id);
        
        await taskRepository.AddAsync(task);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(task.Id);
    }
}