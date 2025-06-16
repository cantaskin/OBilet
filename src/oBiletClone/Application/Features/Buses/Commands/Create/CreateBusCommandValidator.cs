using FluentValidation;

namespace Application.Features.Buses.Commands.Create;

public class CreateBusCommandValidator : AbstractValidator<CreateBusCommand>
{
    public CreateBusCommandValidator()
    {
        RuleFor(c => c.NumberPlate).NotEmpty();
        RuleFor(c => c.DoorGapSize).NotEmpty().GreaterThan(0).LessThanOrEqualTo(2);
        RuleFor(c => c.DoorGapRowIndex).NotEmpty().GreaterThan(0).LessThanOrEqualTo(15);
        RuleFor(c => c.Column).NotEmpty().GreaterThan(0).LessThanOrEqualTo(4);
        RuleFor(c => c.Column).NotEmpty().GreaterThan(0).LessThanOrEqualTo(30);

    }


}