using FluentValidation;

namespace Application.Features.Seats.Commands.Delete;

public class DeleteSeatCommandValidator : AbstractValidator<DeleteSeatCommand>
{
    public DeleteSeatCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}