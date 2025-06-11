using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.BusServices.Queries.GetById;

public class GetByIdBusServiceResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BusId { get; set; }
    public Bus Bus { get; set; }
    public int StartStationId { get; set; }
    public Station StartStation { get; set; }
    public int FinishStationId { get; set; }
    public Station FinishStation { get; set; }
    public int? ParentId { get; set; }
    public BusService Parent { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime FinishTime { get; set; }
}