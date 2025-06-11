using FluentValidation;

namespace Application.Features.Buses.Commands.Delete;

public class DeleteBusCommandValidator : AbstractValidator<DeleteBusCommand>
{
    public DeleteBusCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}