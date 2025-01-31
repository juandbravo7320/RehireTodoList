using FluentValidation;

namespace ToDoList.Application.Tasks.Commands.CreateTask;

public class CreateTaskValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskValidator()
    {   
        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);
    }
}