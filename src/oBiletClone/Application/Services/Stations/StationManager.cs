using Application.Features.Stations.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Stations;

public class StationManager : IStationService
{
    private readonly IStationRepository _stationRepository;
    private readonly StationBusinessRules _stationBusinessRules;

    public StationManager(IStationRepository stationRepository, StationBusinessRules stationBusinessRules)
    {
        _stationRepository = stationRepository;
        _stationBusinessRules = stationBusinessRules;
    }

    public async Task<Station?> GetAsync(
        Expression<Func<Station, bool>> predicate,
        Func<IQueryable<Station>, IIncludableQueryable<Station, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Station? station = await _stationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return station;
    }

    public async Task<IPaginate<Station>?> GetListAsync(
        Expression<Func<Station, bool>>? predicate = null,
        Func<IQueryable<Station>, IOrderedQueryable<Station>>? orderBy = null,
        Func<IQueryable<Station>, IIncludableQueryable<Station, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Station> stationList = await _stationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return stationList;
    }

    public async Task<Station> AddAsync(Station station)
    {
        Station addedStation = await _stationRepository.AddAsync(station);

        return addedStation;
    }

    public async Task<Station> UpdateAsync(Station station)
    {
        Station updatedStation = await _stationRepository.UpdateAsync(station);

        return updatedStation;
    }

    public async Task<Station> DeleteAsync(Station station, bool permanent = false)
    {
        Station deletedStation = await _stationRepository.DeleteAsync(station);

        return deletedStation;
    }
}
