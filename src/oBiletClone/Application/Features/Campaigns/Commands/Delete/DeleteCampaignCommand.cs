using Application.Features.Campaigns.Constants;
using Application.Features.Campaigns.Constants;
using Application.Features.Campaigns.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Campaigns.Constants.CampaignsOperationClaims;

namespace Application.Features.Campaigns.Commands.Delete;

public class DeleteCampaignCommand : IRequest<DeletedCampaignResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, CampaignsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCampaigns"];

    public class DeleteCampaignCommandHandler : IRequestHandler<DeleteCampaignCommand, DeletedCampaignResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICampaignRepository _campaignRepository;
        private readonly CampaignBusinessRules _campaignBusinessRules;

        public DeleteCampaignCommandHandler(IMapper mapper, ICampaignRepository campaignRepository,
                                         CampaignBusinessRules campaignBusinessRules)
        {
            _mapper = mapper;
            _campaignRepository = campaignRepository;
            _campaignBusinessRules = campaignBusinessRules;
        }

        public async Task<DeletedCampaignResponse> Handle(DeleteCampaignCommand request, CancellationToken cancellationToken)
        {
            Campaign? campaign = await _campaignRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _campaignBusinessRules.CampaignShouldExistWhenSelected(campaign);

            await _campaignRepository.DeleteAsync(campaign!);

            DeletedCampaignResponse response = _mapper.Map<DeletedCampaignResponse>(campaign);
            return response;
        }
    }
}