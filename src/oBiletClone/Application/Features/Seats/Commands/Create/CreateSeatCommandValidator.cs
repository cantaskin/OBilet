using FluentValidation;

namespace Application.Features.Seats.Commands.Create;

public class CreateSeatCommandValidator : AbstractValidator<CreateSeatCommand>
{
    public CreateSeatCommandValidator()
    {
        RuleFor(c => c.BusId).NotEmpty();
        RuleFor(c => c.BusInsideSeatId).NotEmpty();
    }
}