using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BusRepository : EfRepositoryBase<Bus, int, BaseDbContext>, IBusRepository
{
    public BusRepository(BaseDbContext context) : base(context)
    {
    }
}