using FluentValidation;

namespace Application.Features.Personels.Commands.Update;

public class UpdatePersonelCommandValidator : AbstractValidator<UpdatePersonelCommand>
{
    public UpdatePersonelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.NationalId).NotEmpty();
    }
}