using FluentValidation;

namespace Application.Features.BusServiceStations.Commands.Create;

public class CreateBusServiceStationCommandValidator : AbstractValidator<CreateBusServiceStationCommand>
{
    public CreateBusServiceStationCommandValidator()
    {
        RuleFor(c => c.BusServiceRootId).NotEmpty();
        RuleFor(c => c.BusServiceId).NotEmpty();
        RuleFor(c => c.BusService).NotEmpty();
        RuleFor(c => c.StationId).NotEmpty();
        RuleFor(c => c.Station).NotEmpty();
        RuleFor(c => c.Order).NotEmpty();
    }
}