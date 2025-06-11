using Application.Features.Campaigns.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Campaigns.Constants.CampaignsOperationClaims;

namespace Application.Features.Campaigns.Queries.GetList;

public class GetListCampaignQuery : IRequest<GetListResponse<GetListCampaignListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListCampaigns({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetCampaigns";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCampaignQueryHandler : IRequestHandler<GetListCampaignQuery, GetListResponse<GetListCampaignListItemDto>>
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMapper _mapper;

        public GetListCampaignQueryHandler(ICampaignRepository campaignRepository, IMapper mapper)
        {
            _campaignRepository = campaignRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCampaignListItemDto>> Handle(GetListCampaignQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Campaign> campaigns = await _campaignRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCampaignListItemDto> response = _mapper.Map<GetListResponse<GetListCampaignListItemDto>>(campaigns);
            return response;
        }
    }
}