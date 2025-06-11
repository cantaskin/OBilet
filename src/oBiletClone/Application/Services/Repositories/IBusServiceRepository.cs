using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBusServiceRepository : IAsyncRepository<BusService, int>, IRepository<BusService, int>
{

}