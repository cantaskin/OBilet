using FluentValidation;

namespace Application.Features.BusServiceStations.Commands.Delete;

public class DeleteBusServiceStationCommandValidator : AbstractValidator<DeleteBusServiceStationCommand>
{
    public DeleteBusServiceStationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}