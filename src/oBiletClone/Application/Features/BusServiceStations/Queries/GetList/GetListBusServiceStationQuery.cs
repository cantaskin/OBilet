using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.BusServiceStations.Queries.GetList;

public class GetListBusServiceStationQuery : IRequest<GetListResponse<GetListBusServiceStationListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListBusServiceStationQueryHandler : IRequestHandler<GetListBusServiceStationQuery, GetListResponse<GetListBusServiceStationListItemDto>>
    {
        private readonly IBusServiceStationRepository _busServiceStationRepository;
        private readonly IMapper _mapper;

        public GetListBusServiceStationQueryHandler(IBusServiceStationRepository busServiceStationRepository, IMapper mapper)
        {
            _busServiceStationRepository = busServiceStationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBusServiceStationListItemDto>> Handle(GetListBusServiceStationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BusServiceStation> busServiceStations = await _busServiceStationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBusServiceStationListItemDto> response = _mapper.Map<GetListResponse<GetListBusServiceStationListItemDto>>(busServiceStations);
            return response;
        }
    }
}