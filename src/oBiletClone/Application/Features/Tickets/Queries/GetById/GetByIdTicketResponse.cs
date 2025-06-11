using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Tickets.Queries.GetById;

public class GetByIdTicketResponse : IResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int BusServiceId { get; set; }
    public int SeatId { get; set; }
    public decimal Price { get; set; }
    public bool IsCancelled { get; set; }
    public bool IsOnHold { get; set; }
    public DateTime? HoldUntil { get; set; }
}