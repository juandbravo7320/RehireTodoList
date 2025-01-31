using FluentValidation;

namespace ToDoList.Application.Users.Commands.UpdateUser;

public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Username)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Permissions)
            .NotEmpty();
    }
}