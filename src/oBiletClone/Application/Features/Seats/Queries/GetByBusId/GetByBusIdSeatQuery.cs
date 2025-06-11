using Application.Features.Seats.Queries.GetById;
using Application.Features.Seats.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Seats.Constants.SeatsOperationClaims;

namespace Application.Features.Seats.Queries.GetByBusId;
public  class GetListByBusIdSeatQuery : IRequest<GetListResponse<GetListSeatListByBusIdItemDto>>
{
    public int BusId { get; set; }

    public  required PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListByBusIdSeats({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetSeats";
    public TimeSpan? SlidingExpiration { get; }

    public class GetByBusIdSeatQueryHandler : IRequestHandler<GetListByBusIdSeatQuery, GetListResponse<GetListSeatListByBusIdItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISeatRepository _seatRepository;
        private readonly SeatBusinessRules _seatBusinessRules;

        public GetByBusIdSeatQueryHandler(IMapper mapper, ISeatRepository seatRepository, SeatBusinessRules seatBusinessRules)
        {
            _mapper = mapper;
            _seatRepository = seatRepository;
            _seatBusinessRules = seatBusinessRules;
        }

        public async Task<GetListResponse<GetListSeatListByBusIdItemDto>> Handle(GetListByBusIdSeatQuery request, CancellationToken cancellationToken)
        {

            IPaginate<Seat> seats = await _seatRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                predicate: s => s.BusId == request.BusId,
                cancellationToken: cancellationToken
            );


            var response = _mapper.Map<GetListResponse<GetListSeatListByBusIdItemDto>>(seats);
            return response;
        }
    }
}
