using Application.Features.BusServiceStations.Constants;
using Application.Features.BusServiceStations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BusServiceStations.Commands.Delete;

public class DeleteBusServiceStationCommand : IRequest<DeletedBusServiceStationResponse>
{
    public int Id { get; set; }

    public class DeleteBusServiceStationCommandHandler : IRequestHandler<DeleteBusServiceStationCommand, DeletedBusServiceStationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBusServiceStationRepository _busServiceStationRepository;
        private readonly BusServiceStationBusinessRules _busServiceStationBusinessRules;

        public DeleteBusServiceStationCommandHandler(IMapper mapper, IBusServiceStationRepository busServiceStationRepository,
                                         BusServiceStationBusinessRules busServiceStationBusinessRules)
        {
            _mapper = mapper;
            _busServiceStationRepository = busServiceStationRepository;
            _busServiceStationBusinessRules = busServiceStationBusinessRules;
        }

        public async Task<DeletedBusServiceStationResponse> Handle(DeleteBusServiceStationCommand request, CancellationToken cancellationToken)
        {
            BusServiceStation? busServiceStation = await _busServiceStationRepository.GetAsync(predicate: bss => bss.Id == request.Id, cancellationToken: cancellationToken);
            await _busServiceStationBusinessRules.BusServiceStationShouldExistWhenSelected(busServiceStation);

            await _busServiceStationRepository.DeleteAsync(busServiceStation!);

            DeletedBusServiceStationResponse response = _mapper.Map<DeletedBusServiceStationResponse>(busServiceStation);
            return response;
        }
    }
}