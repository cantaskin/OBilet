using Application.Features.BusServices.Constants;
using FluentValidation;

namespace Application.Features.BusServices.Commands.CreateWithStationIds;

public class CreateBusServiceWithStationIdsCommandValidator : AbstractValidator<CreateBusServiceWithStationIdsCommand>
{
    public CreateBusServiceWithStationIdsCommandValidator()
    {
        RuleFor(c => c.BusId).NotEmpty();
        RuleFor(c => c.StartTime)
            .NotEmpty()
            .Must(BeAValidStartTime)
            .WithMessage(BusServicesBusinessMessages.BeAValidStartTime);
    }

    private bool BeAValidStartTime(DateTime startTime)
    {
        var now = DateTime.UtcNow;
        return startTime > now.AddHours(1) && startTime < now.AddYears(1);
    }
}