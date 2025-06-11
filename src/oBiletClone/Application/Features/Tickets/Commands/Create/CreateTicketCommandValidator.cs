using FluentValidation;

namespace Application.Features.Tickets.Commands.Create;

public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
{
    public CreateTicketCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.BusServiceId).NotEmpty();
        RuleFor(c => c.SeatId).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
    }
}