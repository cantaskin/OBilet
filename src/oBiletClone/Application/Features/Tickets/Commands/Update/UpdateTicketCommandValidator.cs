using FluentValidation;

namespace Application.Features.Tickets.Commands.Update;

public class UpdateTicketCommandValidator : AbstractValidator<UpdateTicketCommand>
{
    public UpdateTicketCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.BusServiceId).NotEmpty();
        RuleFor(c => c.SeatId).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.IsCancelled).NotEmpty();
        RuleFor(c => c.IsOnHold).NotEmpty();
    }
}