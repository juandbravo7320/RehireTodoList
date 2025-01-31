using FluentValidation;

namespace ToDoList.Application.Tasks.Commands.DeleteTask;

public class DeleteTaskValidator : AbstractValidator<DeleteTaskCommand>
{
    public DeleteTaskValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}