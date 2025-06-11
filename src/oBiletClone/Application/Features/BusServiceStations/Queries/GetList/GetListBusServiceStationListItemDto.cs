using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BusServiceStations.Queries.GetList;

public class GetListBusServiceStationListItemDto : IDto
{
    public int Id { get; set; }
    public int BusServiceRootId { get; set; }
    public int BusServiceId { get; set; }
    public BusService BusService { get; set; }
    public int StationId { get; set; }
    public Station Station { get; set; }
    public int Order { get; set; }
}