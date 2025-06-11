using FluentValidation;

namespace Application.Features.BusServiceStations.Commands.Update;

public class UpdateBusServiceStationCommandValidator : AbstractValidator<UpdateBusServiceStationCommand>
{
    public UpdateBusServiceStationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BusServiceRootId).NotEmpty();
        RuleFor(c => c.BusServiceId).NotEmpty();
        RuleFor(c => c.BusService).NotEmpty();
        RuleFor(c => c.StationId).NotEmpty();
        RuleFor(c => c.Station).NotEmpty();
        RuleFor(c => c.Order).NotEmpty();
    }
}