using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BusServiceStationRepository : EfRepositoryBase<BusServiceStation, int, BaseDbContext>, IBusServiceStationRepository
{
    public BusServiceStationRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<BusServiceStation> GetFirstByOrder(int? busServiceId = null)
    {
        if (busServiceId != null)
        {
            return await Context.BusServiceStations.Where(bss => bss.BusServiceId == busServiceId).OrderBy(bss => bss.Order)
                .FirstOrDefaultAsync();
        }
        
        return await Context.BusServiceStations.OrderBy(bss => bss.Order)
            .FirstOrDefaultAsync();
    }

    public async Task<BusServiceStation> GetLastByOrder(int? busServiceId = null)
    {
        if (busServiceId != null)
        {
            return await Context.BusServiceStations.Where(bss => bss.BusServiceId == busServiceId).OrderBy(bss => bss.Order)
                .LastOrDefaultAsync();
        }

        return await Context.BusServiceStations.OrderBy(bss => bss.Order)
            .LastOrDefaultAsync();
       
    }

    public async Task<List<BusServiceStation>> GetListByOrder(int? busServiceId = null)
    {
        if (busServiceId != null)
        {
            return await Context.BusServiceStations.Where(bss => bss.BusServiceId == busServiceId).OrderBy(bss => bss.Order)
                .ToListAsync();
        }
        return await Context.BusServiceStations.OrderBy(bss => bss.Order)
            .ToListAsync();
    }

}