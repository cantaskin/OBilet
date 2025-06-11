using Application.Features.BusServiceStations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BusServiceStations.Queries.GetById;

public class GetByIdBusServiceStationQuery : IRequest<GetByIdBusServiceStationResponse>
{
    public int Id { get; set; }

    public class GetByIdBusServiceStationQueryHandler : IRequestHandler<GetByIdBusServiceStationQuery, GetByIdBusServiceStationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBusServiceStationRepository _busServiceStationRepository;
        private readonly BusServiceStationBusinessRules _busServiceStationBusinessRules;

        public GetByIdBusServiceStationQueryHandler(IMapper mapper, IBusServiceStationRepository busServiceStationRepository, BusServiceStationBusinessRules busServiceStationBusinessRules)
        {
            _mapper = mapper;
            _busServiceStationRepository = busServiceStationRepository;
            _busServiceStationBusinessRules = busServiceStationBusinessRules;
        }

        public async Task<GetByIdBusServiceStationResponse> Handle(GetByIdBusServiceStationQuery request, CancellationToken cancellationToken)
        {
            BusServiceStation? busServiceStation = await _busServiceStationRepository.GetAsync(predicate: bss => bss.Id == request.Id, cancellationToken: cancellationToken);
            await _busServiceStationBusinessRules.BusServiceStationShouldExistWhenSelected(busServiceStation);

            GetByIdBusServiceStationResponse response = _mapper.Map<GetByIdBusServiceStationResponse>(busServiceStation);
            return response;
        }
    }
}