using Application.Features.BusServiceStations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BusServiceStations.Commands.Update;

public class UpdateBusServiceStationCommand : IRequest<UpdatedBusServiceStationResponse>
{
    public int Id { get; set; }
    public required int BusServiceRootId { get; set; }
    public required int BusServiceId { get; set; }
    public required BusService BusService { get; set; }
    public required int StationId { get; set; }
    public required Station Station { get; set; }
    public required int Order { get; set; }

    public class UpdateBusServiceStationCommandHandler : IRequestHandler<UpdateBusServiceStationCommand, UpdatedBusServiceStationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBusServiceStationRepository _busServiceStationRepository;
        private readonly BusServiceStationBusinessRules _busServiceStationBusinessRules;

        public UpdateBusServiceStationCommandHandler(IMapper mapper, IBusServiceStationRepository busServiceStationRepository,
                                         BusServiceStationBusinessRules busServiceStationBusinessRules)
        {
            _mapper = mapper;
            _busServiceStationRepository = busServiceStationRepository;
            _busServiceStationBusinessRules = busServiceStationBusinessRules;
        }

        public async Task<UpdatedBusServiceStationResponse> Handle(UpdateBusServiceStationCommand request, CancellationToken cancellationToken)
        {
            BusServiceStation? busServiceStation = await _busServiceStationRepository.GetAsync(predicate: bss => bss.Id == request.Id, cancellationToken: cancellationToken);
            await _busServiceStationBusinessRules.BusServiceStationShouldExistWhenSelected(busServiceStation);
            busServiceStation = _mapper.Map(request, busServiceStation);

            await _busServiceStationRepository.UpdateAsync(busServiceStation!);

            UpdatedBusServiceStationResponse response = _mapper.Map<UpdatedBusServiceStationResponse>(busServiceStation);
            return response;
        }
    }
}