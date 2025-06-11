using Application.Features.Campaigns.Constants;
using Application.Features.Campaigns.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Campaigns.Constants.CampaignsOperationClaims;

namespace Application.Features.Campaigns.Queries.GetById;

public class GetByIdCampaignQuery : IRequest<GetByIdCampaignResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCampaignQueryHandler : IRequestHandler<GetByIdCampaignQuery, GetByIdCampaignResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICampaignRepository _campaignRepository;
        private readonly CampaignBusinessRules _campaignBusinessRules;

        public GetByIdCampaignQueryHandler(IMapper mapper, ICampaignRepository campaignRepository, CampaignBusinessRules campaignBusinessRules)
        {
            _mapper = mapper;
            _campaignRepository = campaignRepository;
            _campaignBusinessRules = campaignBusinessRules;
        }

        public async Task<GetByIdCampaignResponse> Handle(GetByIdCampaignQuery request, CancellationToken cancellationToken)
        {
            Campaign? campaign = await _campaignRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _campaignBusinessRules.CampaignShouldExistWhenSelected(campaign);

            GetByIdCampaignResponse response = _mapper.Map<GetByIdCampaignResponse>(campaign);
            return response;
        }
    }
}