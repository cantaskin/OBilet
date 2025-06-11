using FluentValidation;

namespace Application.Features.Personels.Commands.Create;

public class CreatePersonelCommandValidator : AbstractValidator<CreatePersonelCommand>
{
    public CreatePersonelCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.NationalId).NotEmpty();
        RuleFor(c => c.IsMale).NotEmpty();
    }
}