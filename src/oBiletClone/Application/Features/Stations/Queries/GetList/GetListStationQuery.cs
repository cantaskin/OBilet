using Application.Features.Stations.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Stations.Constants.StationsOperationClaims;

namespace Application.Features.Stations.Queries.GetList;

public class GetListStationQuery : IRequest<GetListResponse<GetListStationListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListStations({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetStations";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListStationQueryHandler : IRequestHandler<GetListStationQuery, GetListResponse<GetListStationListItemDto>>
    {
        private readonly IStationRepository _stationRepository;
        private readonly IMapper _mapper;

        public GetListStationQueryHandler(IStationRepository stationRepository, IMapper mapper)
        {
            _stationRepository = stationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStationListItemDto>> Handle(GetListStationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Station> stations = await _stationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStationListItemDto> response = _mapper.Map<GetListResponse<GetListStationListItemDto>>(stations);
            return response;
        }
    }
}