using Application.Features.Stations.Constants;
using Application.Features.Stations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Stations.Constants.StationsOperationClaims;

namespace Application.Features.Stations.Queries.GetById;

public class GetByIdStationQuery : IRequest<GetByIdStationResponse>
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdStationQueryHandler : IRequestHandler<GetByIdStationQuery, GetByIdStationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStationRepository _stationRepository;
        private readonly StationBusinessRules _stationBusinessRules;

        public GetByIdStationQueryHandler(IMapper mapper, IStationRepository stationRepository, StationBusinessRules stationBusinessRules)
        {
            _mapper = mapper;
            _stationRepository = stationRepository;
            _stationBusinessRules = stationBusinessRules;
        }

        public async Task<GetByIdStationResponse> Handle(GetByIdStationQuery request, CancellationToken cancellationToken)
        {
            Station? station = await _stationRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _stationBusinessRules.StationShouldExistWhenSelected(station);

            GetByIdStationResponse response = _mapper.Map<GetByIdStationResponse>(station);
            return response;
        }
    }
}