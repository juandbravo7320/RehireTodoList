using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Abstractions.Authentication;
using ToDoList.Application.Abstractions.Messaging;
using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Repository;
using ToDoList.Domain.Users;

namespace ToDoList.Application.Tasks.Queries.ListTasks;

public class ListTasksQueryHandler(
    IUserContext userContext,
    IUserRepository userRepository,
    ITaskRepository taskRepository) : IQueryHandler<ListTasks, Pageable<TaskResponse>>
{
    public async Task<Result<Pageable<TaskResponse>>> Handle(Queries.ListTasks.ListTasks request, CancellationToken cancellationToken)
    {
        var userId = userContext.UserId;
        var user = await userRepository.FindByIdAsync(userId);

        if (user is null)
            return Result.Failure<Pageable<TaskResponse>>(UserErrors.NotFound);
        
        var queryResult = await FetchTasks(request, user);

        var pageable = new Pageable<TaskResponse>(
            request.Page.Number,
            request.Page.Size,
            queryResult.Item1,
            queryResult.Item2);

        return Result.Success(pageable);
    }

    private async Task<(int, List<TaskResponse>)> FetchTasks(Queries.ListTasks.ListTasks request, User user)
    {
         var query = taskRepository.Queryable()
            .Where(x => x.OwnerId == user.Id)
            .Where(x => request.Description == null || x.Description.Contains(request.Description))
            .Where(x => request.Status == null || x.Status == request.Status)
            .OrderByDescending(x => x.CreatedAtUtc);
         
         var count = await query.CountAsync();

         var tasks = await query
             .Select(x => new TaskResponse(
                 x.Id,
                 x.Description,
                 x.Status,
                 x.CreatedAtUtc))
             .Skip(request.Page.Start())
             .Take(request.Page.Size)
             .ToListAsync();

         return (count, tasks);
    }
}