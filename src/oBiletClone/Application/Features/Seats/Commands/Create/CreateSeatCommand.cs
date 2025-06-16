using Application.Features.Seats.Constants;
using Application.Features.Seats.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Seats.Constants.SeatsOperationClaims;
using Application.Features.Buses.Rules;

namespace Application.Features.Seats.Commands.Create;

public class CreateSeatCommand : IRequest<CreatedSeatResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required int BusId { get; set; }
    public required int LocalSeatId { get; set; }

    //Neighbour Seat But Local Type Yani BusInsideSeatId
    public int? LeftSeatId { get; set; }
    public int? RightSeatId { get; set; }
    public int? TopSeatId { get; set; }
    public int? BottomSeatId { get; set; }

    public string[] Roles => [Admin, Write, SeatsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSeats"];

    public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, CreatedSeatResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISeatRepository _seatRepository;

        private readonly BusBusinessRules _busBusinessRules;
        private readonly SeatBusinessRules _seatBusinessRules;

        public CreateSeatCommandHandler(IMapper mapper, ISeatRepository seatRepository,
                                         BusBusinessRules busBusinessRules, SeatBusinessRules seatBusinessRules)
        {
            _mapper = mapper;
            _seatRepository = seatRepository;
            _busBusinessRules = busBusinessRules;
            _seatBusinessRules = seatBusinessRules;
        }

        public async Task<CreatedSeatResponse> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
        {
            Seat seat = _mapper.Map<Seat>(request);

            await _busBusinessRules.BusIdShouldExistWhenSelected(seat.BusId, cancellationToken);
            await _seatBusinessRules.LocalSeatIdShouldntExistWhenCreated(seat.LocalSeatId, seat.BusId, cancellationToken);

            await _seatRepository.AddAsync(seat);

            CreatedSeatResponse response = _mapper.Map<CreatedSeatResponse>(seat);
            return response;
        }
    }
}