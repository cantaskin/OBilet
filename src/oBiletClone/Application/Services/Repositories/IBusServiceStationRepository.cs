using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBusServiceStationRepository : IAsyncRepository<BusServiceStation, int>, IRepository<BusServiceStation, int>
{
    public Task<BusServiceStation> GetFirstByOrder(int? busServiceId = null);
    public Task<BusServiceStation> GetLastByOrder(int? busServiceId = null);
    public Task<List<BusServiceStation>> GetListByOrder(int? busServiceId = null);
}