using Application.Features.BusServices.Commands.CreateWithStationIds;
using Application.Features.BusServices.Commands.Delete;
using Application.Features.BusServices.Commands.Update;
using Application.Features.BusServices.Queries.GetById;
using Application.Features.BusServices.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Domain.Dtos;

namespace Application.Features.BusServices.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateBusServiceWithStationIdsCommand, BusService>();
        CreateMap<BusService, CreateBusServiceWithStationIdsResponse>();

        CreateMap<UpdateBusServiceCommand, BusService>();
        CreateMap<BusService, UpdatedBusServiceResponse>();

        CreateMap<DeleteBusServiceCommand, BusService>();
        CreateMap<BusService, DeletedBusServiceResponse>();

        CreateMap<BusService, GetByIdBusServiceResponse>();


        CreateMap<Station, StationDto>();

        CreateMap<BusService, GetListBusServiceListItemDto>()
            .ForMember(dest => dest.Stations,
                opt => opt.MapFrom(src => src.BusServiceStations
                    .OrderBy(x => x.Order)
                    .Select(x => x.Station)
                    .ToList()));
        CreateMap<IPaginate<BusService>, GetListResponse<GetListBusServiceListItemDto>>();
    }
}