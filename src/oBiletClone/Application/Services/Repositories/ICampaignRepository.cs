using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICampaignRepository : IAsyncRepository<Campaign, int>, IRepository<Campaign, int>
{
}