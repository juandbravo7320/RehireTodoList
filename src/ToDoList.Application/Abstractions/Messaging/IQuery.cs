using MediatR;
using ToDoList.Domain.Abstractions;

namespace ToDoList.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}