using FluentValidation;

namespace Application.Features.Stations.Commands.Update;

public class UpdateStationCommandValidator : AbstractValidator<UpdateStationCommand>
{
    public UpdateStationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}