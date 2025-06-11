using Application.Features.Campaigns.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Campaigns;

public class CampaignManager : ICampaignService
{
    private readonly ICampaignRepository _campaignRepository;
    private readonly CampaignBusinessRules _campaignBusinessRules;

    public CampaignManager(ICampaignRepository campaignRepository, CampaignBusinessRules campaignBusinessRules)
    {
        _campaignRepository = campaignRepository;
        _campaignBusinessRules = campaignBusinessRules;
    }

    public async Task<Campaign?> GetAsync(
        Expression<Func<Campaign, bool>> predicate,
        Func<IQueryable<Campaign>, IIncludableQueryable<Campaign, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Campaign? campaign = await _campaignRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return campaign;
    }

    public async Task<IPaginate<Campaign>?> GetListAsync(
        Expression<Func<Campaign, bool>>? predicate = null,
        Func<IQueryable<Campaign>, IOrderedQueryable<Campaign>>? orderBy = null,
        Func<IQueryable<Campaign>, IIncludableQueryable<Campaign, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Campaign> campaignList = await _campaignRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return campaignList;
    }

    public async Task<Campaign> AddAsync(Campaign campaign)
    {
        Campaign addedCampaign = await _campaignRepository.AddAsync(campaign);

        return addedCampaign;
    }

    public async Task<Campaign> UpdateAsync(Campaign campaign)
    {
        Campaign updatedCampaign = await _campaignRepository.UpdateAsync(campaign);

        return updatedCampaign;
    }

    public async Task<Campaign> DeleteAsync(Campaign campaign, bool permanent = false)
    {
        Campaign deletedCampaign = await _campaignRepository.DeleteAsync(campaign);

        return deletedCampaign;
    }
}
