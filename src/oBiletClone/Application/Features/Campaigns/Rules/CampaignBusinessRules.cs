using Application.Features.Campaigns.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Campaigns.Rules;

public class CampaignBusinessRules : BaseBusinessRules
{
    private readonly ICampaignRepository _campaignRepository;
    private readonly ILocalizationService _localizationService;

    public CampaignBusinessRules(ICampaignRepository campaignRepository, ILocalizationService localizationService)
    {
        _campaignRepository = campaignRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CampaignsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CampaignShouldExistWhenSelected(Campaign? campaign)
    {
        if (campaign == null)
            await throwBusinessException(CampaignsBusinessMessages.CampaignNotExists);
    }

    public async Task CampaignIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Campaign? campaign = await _campaignRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CampaignShouldExistWhenSelected(campaign);
    }
}