using Application.Features.Buses.Commands.Create;
using Application.Features.Buses.Commands.Delete;
using Application.Features.Buses.Commands.Update;
using Application.Features.Buses.Queries.GetById;
using Application.Features.Buses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Domain.Dtos;
using Application.Features.Buses.Commands.PersonelAssign;

namespace Application.Features.Buses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateBusCommand, Bus>();
        CreateMap<Bus, CreatedBusResponse>();

        CreateMap<UpdateBusCommand, Bus>();
        CreateMap<Bus, UpdatedBusResponse>();

        CreateMap<DeleteBusCommand, Bus>();
        CreateMap<Bus, DeletedBusResponse>();

        CreateMap<Bus, GetByIdBusResponse>()
            .ForMember(dest => dest.PersonelList, opt => opt.MapFrom(src => src.PersonelList))
            .ForMember(dest => dest.Seats, opt => opt.MapFrom( src => src.Seats));

        CreateMap<Bus, PersonelAssignedBusResponse>();

        CreateMap<Bus, GetListBusListItemDto>();
        CreateMap<IPaginate<Bus>, GetListResponse<GetListBusListItemDto>>();
    }
}
