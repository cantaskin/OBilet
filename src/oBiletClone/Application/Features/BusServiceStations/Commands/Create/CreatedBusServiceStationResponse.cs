using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.BusServiceStations.Commands.Create;

public class CreatedBusServiceStationResponse : IResponse
{
    public int Id { get; set; }
    public int BusServiceRootId { get; set; }
    public int BusServiceId { get; set; }
    public BusService BusService { get; set; }
    public int StationId { get; set; }
    public Station Station { get; set; }
    public int Order { get; set; }
}