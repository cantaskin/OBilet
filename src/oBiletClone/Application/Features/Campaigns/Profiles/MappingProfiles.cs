using Application.Features.Campaigns.Commands.Create;
using Application.Features.Campaigns.Commands.Delete;
using Application.Features.Campaigns.Commands.Update;
using Application.Features.Campaigns.Queries.GetById;
using Application.Features.Campaigns.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Campaigns.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCampaignCommand, Campaign>();
        CreateMap<Campaign, CreatedCampaignResponse>();

        CreateMap<UpdateCampaignCommand, Campaign>();
        CreateMap<Campaign, UpdatedCampaignResponse>();

        CreateMap<DeleteCampaignCommand, Campaign>();
        CreateMap<Campaign, DeletedCampaignResponse>();

        CreateMap<Campaign, GetByIdCampaignResponse>();

        CreateMap<Campaign, GetListCampaignListItemDto>();
        CreateMap<IPaginate<Campaign>, GetListResponse<GetListCampaignListItemDto>>();
    }
}