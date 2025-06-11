using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStationRepository : IAsyncRepository<Station, int>, IRepository<Station, int>
{
}