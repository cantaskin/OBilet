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

namespace Application.Features.Seats.Commands.Create;

public class CreateSeatCommand : IRequest<CreatedSeatResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required int BusId { get; set; }
    public required int BusInsideSeatId { get; set; }
    public int? NeighborSeatId { get; set; }
    public int? UserId { get; set; }

    public string[] Roles => [Admin, Write, SeatsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSeats"];

    public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, CreatedSeatResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISeatRepository _seatRepository;
        private readonly SeatBusinessRules _seatBusinessRules;

        public CreateSeatCommandHandler(IMapper mapper, ISeatRepository seatRepository,
                                         SeatBusinessRules seatBusinessRules)
        {
            _mapper = mapper;
            _seatRepository = seatRepository;
            _seatBusinessRules = seatBusinessRules;
        }

        public async Task<CreatedSeatResponse> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
        {
            Seat seat = _mapper.Map<Seat>(request);

            await _seatRepository.AddAsync(seat);

            CreatedSeatResponse response = _mapper.Map<CreatedSeatResponse>(seat);
            return response;
        }
    }
}