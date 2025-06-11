using Domain.Entities;

namespace Application.Features.Seats.Queries.GetByBusId;

public class GetListSeatListByBusIdItemDto
{ 
    public int Id { get; set; }
    public int BusId { get; set; }
    public int BusInsideSeatId { get; set; }
    public int? NeighborSeatId { get; set; }
    public int? UserId { get; set; }
}