using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISeatRepository : IAsyncRepository<Seat, int>, IRepository<Seat, int>
{
    public Task<bool> IsSeatTaken(int busServiceRootId, int seatId, int fromStationId,
        int toStationId);
}