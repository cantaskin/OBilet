using Application.Services.Buses;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BusServiceRepository : EfRepositoryBase<BusService, int, BaseDbContext>, IBusServiceRepository
{
    public BusServiceRepository(BaseDbContext context) : base(context)
    {
    }

}