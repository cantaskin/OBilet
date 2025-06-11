using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Seats.Queries.GetById;

public class GetByIdSeatResponse : IResponse
{
    public int Id { get; set; }
    public int BusId { get; set; }
    public int BusInsideSeatId { get; set; }
    public int? NeighborSeatId { get; set; }
    public int? UserId { get; set; }
}