using Application.Features.BusServices.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BusServices;

public class BusServiceManager : IBusServiceService
{
    private readonly IBusServiceRepository _busServiceRepository;
    private readonly BusServiceBusinessRules _busServiceBusinessRules;

    public BusServiceManager(IBusServiceRepository busServiceRepository, BusServiceBusinessRules busServiceBusinessRules)
    {
        _busServiceRepository = busServiceRepository;
        _busServiceBusinessRules = busServiceBusinessRules;
    }

    public async Task<BusService?> GetAsync(
        Expression<Func<BusService, bool>> predicate,
        Func<IQueryable<BusService>, IIncludableQueryable<BusService, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BusService? busService = await _busServiceRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return busService;
    }

    public async Task<IPaginate<BusService>?> GetListAsync(
        Expression<Func<BusService, bool>>? predicate = null,
        Func<IQueryable<BusService>, IOrderedQueryable<BusService>>? orderBy = null,
        Func<IQueryable<BusService>, IIncludableQueryable<BusService, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BusService> busServiceList = await _busServiceRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return busServiceList;
    }

    public async Task<BusService> AddAsync(BusService busService)
    {
        BusService addedBusService = await _busServiceRepository.AddAsync(busService);

        return addedBusService;
    }

    public async Task<BusService> UpdateAsync(BusService busService)
    {
        BusService updatedBusService = await _busServiceRepository.UpdateAsync(busService);

        return updatedBusService;
    }

    public async Task<BusService> DeleteAsync(BusService busService, bool permanent = false)
    {
        BusService deletedBusService = await _busServiceRepository.DeleteAsync(busService);

        return deletedBusService;
    }


    public int[,,] CreateBusServiceGraph(List<int> stationIds)
    {
        int[,,] matrix = new int[stationIds.Count, stationIds.Count,2];


        for (int i = 0; i < stationIds.Count; i++)
        {
            for (int j = i + 1; j < stationIds.Count; j++)
            {
                var statingVertex = stationIds[i];
                var endingVertex = stationIds[j];
                matrix[i, j - 1, 0] = statingVertex;
                matrix[i, j - 1, 1] = endingVertex;
            }
        }

        return matrix;
    }
}
