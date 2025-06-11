using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Seats.Commands.Update;

public class UpdatedSeatResponse : IResponse
{
    public int Id { get; set; }
    public int BusId { get; set; }
    public Bus Bus { get; set; }
    public int BusInsideSeatId { get; set; }
    public int? NeighborSeatId { get; set; }
    public int? UserId { get; set; }
    public User User { get; set; }
}