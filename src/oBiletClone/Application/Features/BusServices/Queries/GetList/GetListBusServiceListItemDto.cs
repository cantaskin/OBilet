using Domain.Dtos;
using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BusServices.Queries.GetList;

public class GetListBusServiceListItemDto : IDto
{
    public int Id { get; set; }

    public int? RootId { get; set; }
    public string Name { get; set; }
    public int BusId { get; set; }
    public List<StationDto>? Stations { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime FinishTime { get; set; }

}