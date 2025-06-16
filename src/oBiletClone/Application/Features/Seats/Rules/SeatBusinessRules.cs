using Application.Features.Seats.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Seats.Rules;

public class SeatBusinessRules : BaseBusinessRules
{
    private readonly ISeatRepository _seatRepository;
    private readonly ILocalizationService _localizationService;

    public SeatBusinessRules(ISeatRepository seatRepository, ILocalizationService localizationService)
    {
        _seatRepository = seatRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SeatsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SeatShouldExistWhenSelected(Seat? seat)
    {
        if (seat == null)
            await throwBusinessException(SeatsBusinessMessages.SeatNotExists);
    }

    public async Task SeatIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Seat? seat = await _seatRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SeatShouldExistWhenSelected(seat);
    }

    public async Task LocalSeatIdShouldntExistWhenCreated(int localSeatId, int busId, CancellationToken cancellationToken)
    {
        Seat? seat = await _seatRepository.GetAsync(
            predicate: s => s.LocalSeatId == localSeatId && s.BusId == busId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (seat != null)
            await throwBusinessException(SeatsBusinessMessages.LocalSeatIdAlreadyExists);
    }


    public async Task LocalSeatIdShouldExist(int localSeatId, int busId, CancellationToken cancellationToken)
    {
        Seat? seat = await _seatRepository.GetAsync(
            predicate: s => s.LocalSeatId == localSeatId && s.BusId == busId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        if (seat == null)
            await throwBusinessException(SeatsBusinessMessages.LocalSeatIdNotExists);
    }
}