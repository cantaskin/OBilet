using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Campaigns;

public interface ICampaignService
{
    Task<Campaign?> GetAsync(
        Expression<Func<Campaign, bool>> predicate,
        Func<IQueryable<Campaign>, IIncludableQueryable<Campaign, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Campaign>?> GetListAsync(
        Expression<Func<Campaign, bool>>? predicate = null,
        Func<IQueryable<Campaign>, IOrderedQueryable<Campaign>>? orderBy = null,
        Func<IQueryable<Campaign>, IIncludableQueryable<Campaign, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Campaign> AddAsync(Campaign campaign);
    Task<Campaign> UpdateAsync(Campaign campaign);
    Task<Campaign> DeleteAsync(Campaign campaign, bool permanent = false);
}
