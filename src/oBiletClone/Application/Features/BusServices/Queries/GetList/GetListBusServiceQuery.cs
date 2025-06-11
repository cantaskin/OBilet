using Application.Features.BusServices.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.BusServices.Constants.BusServicesOperationClaims;

namespace Application.Features.BusServices.Queries.GetList;

public class GetListBusServiceQuery : IRequest<GetListResponse<GetListBusServiceListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBusServices({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBusServices";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBusServiceQueryHandler : IRequestHandler<GetListBusServiceQuery, GetListResponse<GetListBusServiceListItemDto>>
    {
        private readonly IBusServiceRepository _busServiceRepository;
        private readonly IMapper _mapper;

        public GetListBusServiceQueryHandler(IBusServiceRepository busServiceRepository, IMapper mapper)
        {
            _busServiceRepository = busServiceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBusServiceListItemDto>> Handle(GetListBusServiceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BusService> busServices = await _busServiceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken,
                include:i => i.Include(bs => bs.BusServiceStations)
                    .ThenInclude(bss => bss.Station)
            );

            GetListResponse<GetListBusServiceListItemDto> response = _mapper.Map<GetListResponse<GetListBusServiceListItemDto>>(busServices);
            return response;
        }
    }
}