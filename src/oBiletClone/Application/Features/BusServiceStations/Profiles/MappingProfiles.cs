using Application.Features.BusServiceStations.Commands.Create;
using Application.Features.BusServiceStations.Commands.Delete;
using Application.Features.BusServiceStations.Commands.Update;
using Application.Features.BusServiceStations.Queries.GetById;
using Application.Features.BusServiceStations.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.BusServiceStations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateBusServiceStationCommand, BusServiceStation>();
        CreateMap<BusServiceStation, CreatedBusServiceStationResponse>();

        CreateMap<UpdateBusServiceStationCommand, BusServiceStation>();
        CreateMap<BusServiceStation, UpdatedBusServiceStationResponse>();

        CreateMap<DeleteBusServiceStationCommand, BusServiceStation>();
        CreateMap<BusServiceStation, DeletedBusServiceStationResponse>();

        CreateMap<BusServiceStation, GetByIdBusServiceStationResponse>();

        CreateMap<BusServiceStation, GetListBusServiceStationListItemDto>();
        CreateMap<IPaginate<BusServiceStation>, GetListResponse<GetListBusServiceStationListItemDto>>();
    }
}