using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SeatRepository : EfRepositoryBase<Seat, int, BaseDbContext>, ISeatRepository
{
    public SeatRepository(BaseDbContext context) : base(context)
    {

    }

    public async Task<bool> IsSeatTaken(int busServiceId, int seatId, int fromStationId, int toStationId)
    {
            return await IsSeatTakenFallback(busServiceId,seatId, fromStationId, toStationId);
    }

    private async Task<bool> IsSeatTakenFallback(int busServiceId ,int seatId, int fromStationId, int toStationId)
    {
        var stationOrderList = await Context.BusServiceStations
            .Where(bss => bss.BusServiceId == busServiceId)
            .OrderBy(bss => bss.Order)
            .ToListAsync(); 

        var stationOrders = stationOrderList
            .Select((bss, index) => new { bss.StationId, Order = index })
            .ToDictionary(x => x.StationId, x => x.Order);

        if (!stationOrders.ContainsKey(fromStationId) || !stationOrders.ContainsKey(toStationId))
            return false;

        var requestStart = stationOrders[fromStationId];
        var requestEnd = stationOrders[toStationId];

        var conflictingTickets = await Context.Tickets
            .Where(t =>
                       t.SeatId == seatId &&
                       t.IsOnHold)
            .Select(t => new { t.FromStationId, t.ToStationId })
            .ToListAsync();

        foreach (var ticket in conflictingTickets)
        {
            if (!stationOrders.ContainsKey(ticket.FromStationId) || !stationOrders.ContainsKey(ticket.ToStationId))
                continue;

            var ticketStart = stationOrders[ticket.FromStationId];
            var ticketEnd = stationOrders[ticket.ToStationId];
            if (requestStart < ticketEnd && requestEnd > ticketStart)
                return true;
            if (requestStart < ticketEnd && requestEnd < ticketEnd && ticketStart < requestStart)
                return true;
        }
        return false; 
    }
}