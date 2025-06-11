using FluentValidation;

namespace Application.Features.Buses.Commands.Update;

public class UpdateBusCommandValidator : AbstractValidator<UpdateBusCommand>
{
    public UpdateBusCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.NumberPlate).NotEmpty();
        RuleFor(c => c.SeatCount).NotEmpty();
        RuleFor(c => c.HasOneSeat).NotEmpty();
    }
}