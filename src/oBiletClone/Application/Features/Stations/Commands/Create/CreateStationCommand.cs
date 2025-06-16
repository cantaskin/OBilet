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

namespace Application.Features.Stations.Commands.Create;

public class CreateStationCommand : IRequest<CreatedStationResponse>,  ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest,
{
    public string Name { get; set;  }

    public string[] Roles => [Admin, Write, StationsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetStations"];

    public class CreateStationCommandHandler : IRequestHandler<CreateStationCommand, CreatedStationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStationRepository _stationRepository;
        private readonly StationBusinessRules _stationBusinessRules;

        public CreateStationCommandHandler(IMapper mapper, IStationRepository stationRepository,
                                         StationBusinessRules stationBusinessRules)
        {
            _mapper = mapper;
            _stationRepository = stationRepository;
            _stationBusinessRules = stationBusinessRules;
        }

        public async Task<CreatedStationResponse> Handle(CreateStationCommand request, CancellationToken cancellationToken)
        {
            Station station = _mapper.Map<Station>(request);

            await _stationBusinessRules.StationNameShouldntExistWhenCreated(request.Name, cancellationToken);
            
            await _stationRepository.AddAsync(station);

            CreatedStationResponse response = _mapper.Map<CreatedStationResponse>(station);
            return response;
        }
    }
}