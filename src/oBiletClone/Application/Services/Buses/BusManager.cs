using Application.Features.Buses.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Buses;

public class BusManager : IBusService
{
    private readonly IBusRepository _busRepository;
    private readonly BusBusinessRules _busBusinessRules;

    public BusManager(IBusRepository busRepository, BusBusinessRules busBusinessRules)
    {
        _busRepository = busRepository;
        _busBusinessRules = busBusinessRules;
    }

    public async Task<Bus?> GetAsync(
        Expression<Func<Bus, bool>> predicate,
        Func<IQueryable<Bus>, IIncludableQueryable<Bus, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Bus? bus = await _busRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bus;
    }

    public async Task<IPaginate<Bus>?> GetListAsync(
        Expression<Func<Bus, bool>>? predicate = null,
        Func<IQueryable<Bus>, IOrderedQueryable<Bus>>? orderBy = null,
        Func<IQueryable<Bus>, IIncludableQueryable<Bus, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Bus> busList = await _busRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return busList;
    }

    public async Task<Bus> AddAsync(Bus bus)
    {
        Bus addedBus = await _busRepository.AddAsync(bus);

        return addedBus;
    }

    public async Task<Bus> UpdateAsync(Bus bus)
    {
        Bus updatedBus = await _busRepository.UpdateAsync(bus);

        return updatedBus;
    }

    public async Task<Bus> DeleteAsync(Bus bus, bool permanent = false)
    {
        Bus deletedBus = await _busRepository.DeleteAsync(bus);

        return deletedBus;
    }
}
