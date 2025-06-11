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

namespace Application.Features.Campaigns.Commands.Create;

public class CreateCampaignCommand : IRequest<CreatedCampaignResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal DiscountPercentage { get; set; }
    public decimal? DiscountFixedAmount { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }

    public string[] Roles => [Admin, Write, CampaignsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCampaigns"];

    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, CreatedCampaignResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICampaignRepository _campaignRepository;
        private readonly CampaignBusinessRules _campaignBusinessRules;

        public CreateCampaignCommandHandler(IMapper mapper, ICampaignRepository campaignRepository,
                                         CampaignBusinessRules campaignBusinessRules)
        {
            _mapper = mapper;
            _campaignRepository = campaignRepository;
            _campaignBusinessRules = campaignBusinessRules;
        }

        public async Task<CreatedCampaignResponse> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            Campaign campaign = _mapper.Map<Campaign>(request);

            await _campaignRepository.AddAsync(campaign);

            CreatedCampaignResponse response = _mapper.Map<CreatedCampaignResponse>(campaign);
            return response;
        }
    }
}