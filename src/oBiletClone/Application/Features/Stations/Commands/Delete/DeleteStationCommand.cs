using Application.Features.Stations.Constants;
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

namespace Application.Features.Stations.Commands.Delete;

public class DeleteStationCommand : IRequest<DeletedStationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, StationsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetStations"];

    public class DeleteStationCommandHandler : IRequestHandler<DeleteStationCommand, DeletedStationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStationRepository _stationRepository;
        private readonly StationBusinessRules _stationBusinessRules;

        public DeleteStationCommandHandler(IMapper mapper, IStationRepository stationRepository,
                                         StationBusinessRules stationBusinessRules)
        {
            _mapper = mapper;
            _stationRepository = stationRepository;
            _stationBusinessRules = stationBusinessRules;
        }

        public async Task<DeletedStationResponse> Handle(DeleteStationCommand request, CancellationToken cancellationToken)
        {
            Station? station = await _stationRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _stationBusinessRules.StationShouldExistWhenSelected(station);

            await _stationRepository.DeleteAsync(station!);

            DeletedStationResponse response = _mapper.Map<DeletedStationResponse>(station);
            return response;
        }
    }
}