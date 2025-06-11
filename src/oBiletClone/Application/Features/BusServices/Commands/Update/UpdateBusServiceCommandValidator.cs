using FluentValidation;

namespace Application.Features.BusServices.Commands.Update;

public class UpdateBusServiceCommandValidator : AbstractValidator<UpdateBusServiceCommand>
{
    public UpdateBusServiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StartTime).NotEmpty();
        RuleFor(c => c.FinishTime).NotEmpty();
    }
}