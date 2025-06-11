using Application.Features.BusServices.Rules;
using Application.Features.BusServiceStations.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BusServiceStations;

public class BusServiceStationManager : IBusServiceStationService
{
    private readonly IBusServiceStationRepository _busServiceStationRepository;
    private readonly IBusServiceRepository _busServiceRepository;
    private readonly BusServiceStationBusinessRules _busServiceStationBusinessRules;
    private readonly BusServiceBusinessRules _busServiceBusinessRules;

    public BusServiceStationManager(IBusServiceStationRepository busServiceStationRepository, BusServiceStationBusinessRules busServiceStationBusinessRules, IBusServiceRepository busServiceRepository, BusServiceBusinessRules busServiceBusinessRules)
    {
        _busServiceStationRepository = busServiceStationRepository;
        _busServiceStationBusinessRules = busServiceStationBusinessRules;
        _busServiceRepository = busServiceRepository;
        _busServiceBusinessRules = busServiceBusinessRules;
    }

    public async Task<BusServiceStation?> GetAsync(
        Expression<Func<BusServiceStation, bool>> predicate,
        Func<IQueryable<BusServiceStation>, IIncludableQueryable<BusServiceStation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BusServiceStation? busServiceStation = await _busServiceStationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return busServiceStation;
    }

    public async Task<IPaginate<BusServiceStation>?> GetListAsync(
        Expression<Func<BusServiceStation, bool>>? predicate = null,
        Func<IQueryable<BusServiceStation>, IOrderedQueryable<BusServiceStation>>? orderBy = null,
        Func<IQueryable<BusServiceStation>, IIncludableQueryable<BusServiceStation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BusServiceStation> busServiceStationList = await _busServiceStationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return busServiceStationList;
    }

    public async Task<BusServiceStation> AddAsync(BusServiceStation busServiceStation)
    {
        BusServiceStation addedBusServiceStation = await _busServiceStationRepository.AddAsync(busServiceStation);

        return addedBusServiceStation;
    }

    public async Task<BusServiceStation> UpdateAsync(BusServiceStation busServiceStation)
    {
        BusServiceStation updatedBusServiceStation = await _busServiceStationRepository.UpdateAsync(busServiceStation);

        return updatedBusServiceStation;
    }

    public async Task<BusServiceStation> DeleteAsync(BusServiceStation busServiceStation, bool permanent = false)
    {
        BusServiceStation deletedBusServiceStation = await _busServiceStationRepository.DeleteAsync(busServiceStation);

        return deletedBusServiceStation;
    }

    public async Task<Dictionary<int, int>> GetStationIdOrderDictionary(int busServiceId, CancellationToken cancellationToken = default)
    {
        await _busServiceBusinessRules.BusServiceIdShouldExistWhenSelected(busServiceId,cancellationToken);


        Dictionary<int, Dictionary<int, int>> busServiceStationOrders = new();

        List<BusServiceStation> stationList = await _busServiceStationRepository.GetListByOrder(busServiceId);
        if (stationList == null || !stationList.Any())
        { 
            return new Dictionary<int, int>();
        }

        Dictionary<int, int> stationOrderDict = stationList.Select((station, index) => new { station.StationId, Order = index })
                .ToDictionary(x => x.StationId, x => x.Order);

        return stationOrderDict;
    }
}
