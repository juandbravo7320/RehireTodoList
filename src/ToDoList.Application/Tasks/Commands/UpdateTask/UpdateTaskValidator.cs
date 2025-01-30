using FluentValidation;

namespace ToDoList.Application.Tasks.Commands.UpdateTask;

public class UpdateTaskValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        
        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);
        
        RuleFor(x => x.Status)
            .IsInEnum();
    }
}