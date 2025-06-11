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

namespace Application.Features.Seats.Commands.Update;

public class UpdateSeatCommand : IRequest<UpdatedSeatResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required int BusId { get; set; }
    public required int BusInsideSeatId { get; set; }
    public int? NeighborSeatId { get; set; }
    public int? UserId { get; set; }

    public string[] Roles => [Admin, Write, SeatsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSeats"];

    public class UpdateSeatCommandHandler : IRequestHandler<UpdateSeatCommand, UpdatedSeatResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISeatRepository _seatRepository;
        private readonly SeatBusinessRules _seatBusinessRules;

        public UpdateSeatCommandHandler(IMapper mapper, ISeatRepository seatRepository,
                                         SeatBusinessRules seatBusinessRules)
        {
            _mapper = mapper;
            _seatRepository = seatRepository;
            _seatBusinessRules = seatBusinessRules;
        }

        public async Task<UpdatedSeatResponse> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
        {
            Seat? seat = await _seatRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _seatBusinessRules.SeatShouldExistWhenSelected(seat);
            seat = _mapper.Map(request, seat);

            await _seatRepository.UpdateAsync(seat!);

            UpdatedSeatResponse response = _mapper.Map<UpdatedSeatResponse>(seat);
            return response;
        }
    }
}