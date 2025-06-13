using Application.Features.BusServices.Rules;
using Application.Features.BusServiceStations.Rules;
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

namespace Application.Features.Tickets.Commands.Create;

public class CreateTicketCommand : IRequest<CreatedTicketResponse>,  ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest, ISecuredRequest
{
    public required Guid UserId { get; set; }
    public required int BusServiceId { get; set; }
    public required int SeatId { get; set; }
    public required decimal Price { get; set; }
   // public int? CampaignId { get; set; }
    public string[] Roles => [Admin, Write, TicketsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTickets"];

    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, CreatedTicketResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;
        private readonly IBusServiceStationRepository _busServiceStationRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly BusServiceBusinessRules _busServiceBusinessRules;
        private readonly IBusServiceRepository _busServiceRepository;
        private readonly BusServiceStationBusinessRules _busServiceStationBusinessRules;
        private readonly TicketBusinessRules _ticketBusinessRules;

        public CreateTicketCommandHandler(IMapper mapper, ITicketRepository ticketRepository,
                                         TicketBusinessRules ticketBusinessRules, ISeatRepository seatRepository, IBusServiceRepository busServiceRepository, IBusServiceStationRepository busServiceStationRepository, BusServiceBusinessRules busServiceBusinessRules, BusServiceStationBusinessRules busServiceStationBusinessRules)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
            _ticketBusinessRules = ticketBusinessRules;
            _seatRepository = seatRepository;
            _busServiceRepository = busServiceRepository;
            _busServiceStationRepository = busServiceStationRepository;
            _busServiceBusinessRules = busServiceBusinessRules;
            _busServiceStationBusinessRules = busServiceStationBusinessRules;
        }

        public async Task<CreatedTicketResponse> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            Ticket ticket = _mapper.Map<Ticket>(request);

            var busService = await _busServiceRepository.GetAsync(bs => bs.Id == request.BusServiceId, cancellationToken: cancellationToken);
            await _busServiceBusinessRules.BusServiceShouldExistWhenSelected(busService);

            var firstByOrder = await _busServiceStationRepository.GetFirstByOrder(busService!.Id);
            await _busServiceStationBusinessRules.BusServiceStationShouldExistWhenSelected(firstByOrder);


            var lastByOrder = await _busServiceStationRepository.GetLastByOrder(busService.Id);
            await _busServiceStationBusinessRules.BusServiceStationShouldExistWhenSelected(lastByOrder);

            var IseatTaken = await _seatRepository.IsSeatTaken(busService.RootId,ticket.SeatId, firstByOrder.StationId, lastByOrder.StationId);
            
            if (IseatTaken)
                await _ticketBusinessRules.SeatShouldNotBeBooked();

            
            ticket.FromStationId = firstByOrder.StationId;
            ticket.ToStationId = lastByOrder.StationId;
            ticket.IsOnHold = true;

            await _ticketRepository.AddAsync(ticket, cancellationToken);

            CreatedTicketResponse response = _mapper.Map<CreatedTicketResponse>(ticket);
            return response;
        }
    }
}