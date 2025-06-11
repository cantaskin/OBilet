using Application.Features.Buses.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Buses.Constants.BusesOperationClaims;

namespace Application.Features.Buses.Queries.GetList;

public class GetListBusQuery : IRequest<GetListResponse<GetListBusListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBuses({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBuses";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBusQueryHandler : IRequestHandler<GetListBusQuery, GetListResponse<GetListBusListItemDto>>
    {
        private readonly IBusRepository _busRepository;
        private readonly IMapper _mapper;

        public GetListBusQueryHandler(IBusRepository busRepository, IMapper mapper)
        {
            _busRepository = busRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBusListItemDto>> Handle(GetListBusQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Bus> buses = await _busRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBusListItemDto> response = _mapper.Map<GetListResponse<GetListBusListItemDto>>(buses);
            return response;
        }
    }
}