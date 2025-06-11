using Application.Features.Personels.Commands.Create;
using Application.Features.Personels.Commands.Delete;
using Application.Features.Personels.Commands.Update;
using Application.Features.Personels.Queries.GetById;
using Application.Features.Personels.Queries.GetList;
using AutoMapper;
using Domain.Dtos;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Personels.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePersonelCommand, Personel>();
        CreateMap<Personel, CreatedPersonelResponse>();

        CreateMap<UpdatePersonelCommand, Personel>();
        CreateMap<Personel, UpdatedPersonelResponse>();

        CreateMap<DeletePersonelCommand, Personel>();
        CreateMap<Personel, DeletedPersonelResponse>();

        CreateMap<Personel, PersonelDto>().ReverseMap();

        CreateMap<Personel, GetByIdPersonelResponse>();

        CreateMap<Personel, GetListPersonelListItemDto>();
        CreateMap<IPaginate<Personel>, GetListResponse<GetListPersonelListItemDto>>();
    }
}