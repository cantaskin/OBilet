using Application.Features.Stations.Constants;
using Application.Features.Stations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Stations.Constants.StationsOperationClaims;

namespace Application.Features.Stations.Commands.Update;

public class UpdateStationCommand : IRequest<UpdatedStationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string[] Roles => [Admin, Write, StationsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetStations"];

    public class UpdateStationCommandHandler : IRequestHandler<UpdateStationCommand, UpdatedStationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStationRepository _stationRepository;
        private readonly StationBusinessRules _stationBusinessRules;

        public UpdateStationCommandHandler(IMapper mapper, IStationRepository stationRepository,
                                         StationBusinessRules stationBusinessRules)
        {
            _mapper = mapper;
            _stationRepository = stationRepository;
            _stationBusinessRules = stationBusinessRules;
        }

        public async Task<UpdatedStationResponse> Handle(UpdateStationCommand request, CancellationToken cancellationToken)
        {
            Station? station = await _stationRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);

            await _stationBusinessRules.StationShouldExistWhenSelected(station);
            await _stationBusinessRules.StationNameShouldntExistWhenCreated(request.Name, cancellationToken);

            station = _mapper.Map(request, station);

            await _stationRepository.UpdateAsync(station!);

            UpdatedStationResponse response = _mapper.Map<UpdatedStationResponse>(station);
            return response;
        }
    }
}