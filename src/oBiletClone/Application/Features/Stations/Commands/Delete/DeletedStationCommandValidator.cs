using FluentValidation;

namespace Application.Features.Stations.Commands.Delete;

public class DeleteStationCommandValidator : AbstractValidator<DeleteStationCommand>
{
    public DeleteStationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}