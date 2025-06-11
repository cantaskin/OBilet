using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBusRepository : IAsyncRepository<Bus, int>, IRepository<Bus, int>
{
}