using FluentValidation;

namespace Application.Features.Seats.Commands.Update;

public class UpdateSeatCommandValidator : AbstractValidator<UpdateSeatCommand>
{
    public UpdateSeatCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BusId).NotEmpty();
    }
}