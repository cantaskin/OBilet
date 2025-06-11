using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CampaignRepository : EfRepositoryBase<Campaign, int, BaseDbContext>, ICampaignRepository
{
    public CampaignRepository(BaseDbContext context) : base(context)
    {
    }
}