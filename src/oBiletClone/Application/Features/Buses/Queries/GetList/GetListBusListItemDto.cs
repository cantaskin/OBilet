using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Buses.Queries.GetList;

public class GetListBusListItemDto : IDto
{
    public int Id { get; set; }
    public string NumberPlate { get; set; }
    public int SeatCount { get; set; }
    public bool HasOneSeat { get; set; }
}