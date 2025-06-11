using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Tickets.Queries.GetList;

public class GetListTicketListItemDto : IDto
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