using Application.Features.Tickets.Constants;
using Application.Features.Tickets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Tickets.Constants.TicketsOperationClaims;

namespace Application.Features.Tickets.Commands.Update;

public class UpdateTicketCommand : IRequest<UpdatedTicketResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required Guid UserId { get; set; }
    public required int BusServiceId { get; set; }
    public required int SeatId { get; set; }
    public required decimal Price { get; set; }
    public required bool IsCancelled { get; set; }
    public required bool IsOnHold { get; set; }
    public DateTime? HoldUntil { get; set; }

    public string[] Roles => [Admin, Write, TicketsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTickets"];

    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, UpdatedTicketResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;
        private readonly TicketBusinessRules _ticketBusinessRules;

        public UpdateTicketCommandHandler(IMapper mapper, ITicketRepository ticketRepository,
                                         TicketBusinessRules ticketBusinessRules)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
            _ticketBusinessRules = ticketBusinessRules;
        }

        public async Task<UpdatedTicketResponse> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            Ticket? ticket = await _ticketRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _ticketBusinessRules.TicketShouldExistWhenSelected(ticket);
            ticket = _mapper.Map(request, ticket);

            await _ticketRepository.UpdateAsync(ticket!);

            UpdatedTicketResponse response = _mapper.Map<UpdatedTicketResponse>(ticket);
            return response;
        }
    }
}