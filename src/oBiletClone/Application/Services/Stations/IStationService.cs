using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Stations;

public interface IStationService
{
    Task<Station?> GetAsync(
        Expression<Func<Station, bool>> predicate,
        Func<IQueryable<Station>, IIncludableQueryable<Station, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Station>?> GetListAsync(
        Expression<Func<Station, bool>>? predicate = null,
        Func<IQueryable<Station>, IOrderedQueryable<Station>>? orderBy = null,
        Func<IQueryable<Station>, IIncludableQueryable<Station, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Station> AddAsync(Station station);
    Task<Station> UpdateAsync(Station station);
    Task<Station> DeleteAsync(Station station, bool permanent = false);
}
