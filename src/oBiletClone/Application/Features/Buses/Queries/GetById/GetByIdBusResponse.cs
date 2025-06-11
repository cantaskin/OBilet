using Domain.Dtos;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Buses.Queries.GetById;

public class GetByIdBusResponse : IResponse
{
    public int Id { get; set; }
    public string NumberPlate { get; set; }
    public int SeatCount { get; set; }
    public bool HasOneSeat { get; set; }
    public List<PersonelDto> PersonelList { get; set; }
    public List<SeatDto> Seats { get; set; } 
}