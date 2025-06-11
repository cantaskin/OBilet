using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BusServiceStations;

public interface IBusServiceStationService
{
    Task<BusServiceStation?> GetAsync(
        Expression<Func<BusServiceStation, bool>> predicate,
        Func<IQueryable<BusServiceStation>, IIncludableQueryable<BusServiceStation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BusServiceStation>?> GetListAsync(
        Expression<Func<BusServiceStation, bool>>? predicate = null,
        Func<IQueryable<BusServiceStation>, IOrderedQueryable<BusServiceStation>>? orderBy = null,
        Func<IQueryable<BusServiceStation>, IIncludableQueryable<BusServiceStation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BusServiceStation> AddAsync(BusServiceStation busServiceStation);
    Task<BusServiceStation> UpdateAsync(BusServiceStation busServiceStation);
    Task<BusServiceStation> DeleteAsync(BusServiceStation busServiceStation, bool permanent = false);

    Task<Dictionary<int,int>> GetStationIdOrderDictionary(int busServiceId,
        CancellationToken cancellationToken = default
    );
}
