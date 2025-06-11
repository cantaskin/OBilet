using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Seats;

public interface ISeatService
{
    Task<Seat?> GetAsync(
        Expression<Func<Seat, bool>> predicate,
        Func<IQueryable<Seat>, IIncludableQueryable<Seat, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Seat>?> GetListAsync(
        Expression<Func<Seat, bool>>? predicate = null,
        Func<IQueryable<Seat>, IOrderedQueryable<Seat>>? orderBy = null,
        Func<IQueryable<Seat>, IIncludableQueryable<Seat, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Seat> AddAsync(Seat seat);
    Task<Seat> UpdateAsync(Seat seat);
    Task<Seat> DeleteAsync(Seat seat, bool permanent = false);
}
