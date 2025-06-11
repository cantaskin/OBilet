using Application.Features.Stations.Commands.Create;
using Application.Features.Stations.Commands.Delete;
using Application.Features.Stations.Commands.Update;
using Application.Features.Stations.Queries.GetById;
using Application.Features.Stations.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Stations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateStationCommand, Station>();
        CreateMap<Station, CreatedStationResponse>();

        CreateMap<UpdateStationCommand, Station>();
        CreateMap<Station, UpdatedStationResponse>();

        CreateMap<DeleteStationCommand, Station>();
        CreateMap<Station, DeletedStationResponse>();

        CreateMap<Station, GetByIdStationResponse>();

        CreateMap<Station, GetListStationListItemDto>();
        CreateMap<IPaginate<Station>, GetListResponse<GetListStationListItemDto>>();
    }
}