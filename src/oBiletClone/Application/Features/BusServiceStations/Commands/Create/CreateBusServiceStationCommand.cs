using Application.Features.BusServiceStations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BusServiceStations.Commands.Create;

public class CreateBusServiceStationCommand : IRequest<CreatedBusServiceStationResponse>
{
    public required int BusServiceRootId { get; set; }
    public required int BusServiceId { get; set; }
    public required BusService BusService { get; set; }
    public required int StationId { get; set; }
    public required Station Station { get; set; }
    public required int Order { get; set; }

    public class CreateBusServiceStationCommandHandler : IRequestHandler<CreateBusServiceStationCommand, CreatedBusServiceStationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBusServiceStationRepository _busServiceStationRepository;
        private readonly BusServiceStationBusinessRules _busServiceStationBusinessRules;

        public CreateBusServiceStationCommandHandler(IMapper mapper, IBusServiceStationRepository busServiceStationRepository,
                                         BusServiceStationBusinessRules busServiceStationBusinessRules)
        {
            _mapper = mapper;
            _busServiceStationRepository = busServiceStationRepository;
            _busServiceStationBusinessRules = busServiceStationBusinessRules;
        }

        public async Task<CreatedBusServiceStationResponse> Handle(CreateBusServiceStationCommand request, CancellationToken cancellationToken)
        {
            BusServiceStation busServiceStation = _mapper.Map<BusServiceStation>(request);

            await _busServiceStationRepository.AddAsync(busServiceStation);

            CreatedBusServiceStationResponse response = _mapper.Map<CreatedBusServiceStationResponse>(busServiceStation);
            return response;
        }
    }
}