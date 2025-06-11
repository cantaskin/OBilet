using Application.Features.Seats.Constants;
using Application.Features.Seats.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Seats.Constants.SeatsOperationClaims;

namespace Application.Features.Seats.Queries.GetById;

public class GetByIdSeatQuery : IRequest<GetByIdSeatResponse>
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdSeatQueryHandler : IRequestHandler<GetByIdSeatQuery, GetByIdSeatResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISeatRepository _seatRepository;
        private readonly SeatBusinessRules _seatBusinessRules;

        public GetByIdSeatQueryHandler(IMapper mapper, ISeatRepository seatRepository, SeatBusinessRules seatBusinessRules)
        {
            _mapper = mapper;
            _seatRepository = seatRepository;
            _seatBusinessRules = seatBusinessRules;
        }

        public async Task<GetByIdSeatResponse> Handle(GetByIdSeatQuery request, CancellationToken cancellationToken)
        {
            Seat? seat = await _seatRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _seatBusinessRules.SeatShouldExistWhenSelected(seat);

            GetByIdSeatResponse response = _mapper.Map<GetByIdSeatResponse>(seat);
            return response;
        }
    }
}