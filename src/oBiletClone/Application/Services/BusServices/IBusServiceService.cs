using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BusServices;

public interface IBusServiceService
{
    Task<BusService?> GetAsync(
        Expression<Func<BusService, bool>> predicate,
        Func<IQueryable<BusService>, IIncludableQueryable<BusService, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BusService>?> GetListAsync(
        Expression<Func<BusService, bool>>? predicate = null,
        Func<IQueryable<BusService>, IOrderedQueryable<BusService>>? orderBy = null,
        Func<IQueryable<BusService>, IIncludableQueryable<BusService, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BusService> AddAsync(BusService busService);
    Task<BusService> UpdateAsync(BusService busService);
    Task<BusService> DeleteAsync(BusService busService, bool permanent = false);
    int[,,] CreateBusServiceGraph(List<int> stationIds);

}
