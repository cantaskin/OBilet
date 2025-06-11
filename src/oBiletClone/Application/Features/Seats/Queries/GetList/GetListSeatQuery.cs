using Application.Features.Seats.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Seats.Constants.SeatsOperationClaims;

namespace Application.Features.Seats.Queries.GetList;

public class GetListSeatQuery : IRequest<GetListResponse<GetListSeatListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListSeats({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetSeats";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSeatQueryHandler : IRequestHandler<GetListSeatQuery, GetListResponse<GetListSeatListItemDto>>
    {
        private readonly ISeatRepository _seatRepository;
        private readonly IMapper _mapper;

        public GetListSeatQueryHandler(ISeatRepository seatRepository, IMapper mapper)
        {
            _seatRepository = seatRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSeatListItemDto>> Handle(GetListSeatQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Seat> seats = await _seatRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSeatListItemDto> response = _mapper.Map<GetListResponse<GetListSeatListItemDto>>(seats);
            return response;
        }
    }
}