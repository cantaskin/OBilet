using Application.Features.Seats.Constants;
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

namespace Application.Features.Seats.Commands.Delete;

public class DeleteSeatCommand : IRequest<DeletedSeatResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, SeatsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSeats"];

    public class DeleteSeatCommandHandler : IRequestHandler<DeleteSeatCommand, DeletedSeatResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISeatRepository _seatRepository;
        private readonly SeatBusinessRules _seatBusinessRules;

        public DeleteSeatCommandHandler(IMapper mapper, ISeatRepository seatRepository,
                                         SeatBusinessRules seatBusinessRules)
        {
            _mapper = mapper;
            _seatRepository = seatRepository;
            _seatBusinessRules = seatBusinessRules;
        }

        public async Task<DeletedSeatResponse> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
        {
            Seat? seat = await _seatRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _seatBusinessRules.SeatShouldExistWhenSelected(seat);

            await _seatRepository.DeleteAsync(seat!);

            DeletedSeatResponse response = _mapper.Map<DeletedSeatResponse>(seat);
            return response;
        }
    }
}