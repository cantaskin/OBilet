using Application.Features.Seats.Commands.Create;
using Application.Features.Seats.Commands.Delete;
using Application.Features.Seats.Commands.Update;
using Application.Features.Seats.Queries.GetById;
using Application.Features.Seats.Queries.GetList;
using AutoMapper;
using Domain.Dtos;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Seats.Queries.GetByBusId;

namespace Application.Features.Seats.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSeatCommand, Seat>();
        CreateMap<Seat, CreatedSeatResponse>();

        CreateMap<UpdateSeatCommand, Seat>();
        CreateMap<Seat, UpdatedSeatResponse>();

        CreateMap<DeleteSeatCommand, Seat>();
        CreateMap<Seat, DeletedSeatResponse>();

        CreateMap<Seat, GetByIdSeatResponse>();


        CreateMap<Seat, GetListSeatListByBusIdItemDto>();


        CreateMap<Seat, SeatDto>();

        CreateMap<Seat, GetListSeatListItemDto>();

        CreateMap<IPaginate<Seat>, GetListResponse<GetListSeatListItemDto>>();
        CreateMap<IPaginate<Seat>, GetListResponse<GetListSeatListByBusIdItemDto>>();
    }
}