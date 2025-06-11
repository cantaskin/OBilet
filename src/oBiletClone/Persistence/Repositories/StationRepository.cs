using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StationRepository : EfRepositoryBase<Station, int, BaseDbContext>, IStationRepository
{
    public StationRepository(BaseDbContext context) : base(context)
    {
    }
}