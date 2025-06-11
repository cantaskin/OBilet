using Application.Features.Seats.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Seats;

public class SeatManager : ISeatService
{
    private readonly ISeatRepository _seatRepository;
    private readonly SeatBusinessRules _seatBusinessRules;

    public SeatManager(ISeatRepository seatRepository, SeatBusinessRules seatBusinessRules)
    {
        _seatRepository = seatRepository;
        _seatBusinessRules = seatBusinessRules;
    }

    public async Task<Seat?> GetAsync(
        Expression<Func<Seat, bool>> predicate,
        Func<IQueryable<Seat>, IIncludableQueryable<Seat, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Seat? seat = await _seatRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return seat;
    }

    public async Task<IPaginate<Seat>?> GetListAsync(
        Expression<Func<Seat, bool>>? predicate = null,
        Func<IQueryable<Seat>, IOrderedQueryable<Seat>>? orderBy = null,
        Func<IQueryable<Seat>, IIncludableQueryable<Seat, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Seat> seatList = await _seatRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return seatList;
    }

    public async Task<Seat> AddAsync(Seat seat)
    {
        Seat addedSeat = await _seatRepository.AddAsync(seat);

        return addedSeat;
    }

    public async Task<Seat> UpdateAsync(Seat seat)
    {
        Seat updatedSeat = await _seatRepository.UpdateAsync(seat);

        return updatedSeat;
    }

    public async Task<Seat> DeleteAsync(Seat seat, bool permanent = false)
    {
        Seat deletedSeat = await _seatRepository.DeleteAsync(seat);

        return deletedSeat;
    }
}
