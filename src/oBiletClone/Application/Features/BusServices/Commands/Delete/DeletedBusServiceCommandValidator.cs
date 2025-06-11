using FluentValidation;

namespace Application.Features.BusServices.Commands.Delete;

public class DeleteBusServiceCommandValidator : AbstractValidator<DeleteBusServiceCommand>
{
    public DeleteBusServiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}