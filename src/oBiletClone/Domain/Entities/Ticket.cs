using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Ticket : Entity<int>
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public int BusServiceId { get; set; }
    public BusService BusService { get; set; }

    public int FromStationId { get; set; }
    public Station FromStation { get; set; }
    public int ToStationId { get; set; }
    public Station ToStation { get; set; }

    public int SeatId { get; set; }
    public Seat Seat { get; set; }
    public decimal Price { get; set; } 
    public decimal DiscountAmount { get; set; } 
    public decimal FinalPrice => Price - DiscountAmount; 
    public int? CampaignId { get; set; }
    public Campaign Campaign { get; set; } 
    public bool IsCancelled { get; set; } = false;
    public bool IsOnHold { get; set; } = false;
    public DateTime? HoldUntil { get; set; }  
}
