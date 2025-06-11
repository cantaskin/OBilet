using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Buses;

public interface IBusService
{
    Task<Bus?> GetAsync(
        Expression<Func<Bus, bool>> predicate,
        Func<IQueryable<Bus>, IIncludableQueryable<Bus, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Bus>?> GetListAsync(
        Expression<Func<Bus, bool>>? predicate = null,
        Func<IQueryable<Bus>, IOrderedQueryable<Bus>>? orderBy = null,
        Func<IQueryable<Bus>, IIncludableQueryable<Bus, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Bus> AddAsync(Bus bus);
    Task<Bus> UpdateAsync(Bus bus);
    Task<Bus> DeleteAsync(Bus bus, bool permanent = false);
}
