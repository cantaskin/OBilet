using Application.Features.Buses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Org.BouncyCastle.Crypto;

namespace Application.Features.Buses.Rules;

public class BusBusinessRules : BaseBusinessRules
{
    private readonly IBusRepository _busRepository;
    private readonly ILocalizationService _localizationService;

    public BusBusinessRules(IBusRepository busRepository, ILocalizationService localizationService)
    {
        _busRepository = busRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BusesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BusShouldExistWhenSelected(Bus? bus)
    {
        if (bus == null)
            await throwBusinessException(BusesBusinessMessages.BusNotExists);
    }

    public async Task BusIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Bus? bus = await _busRepository.GetAsync(
            predicate: b => b.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BusShouldExistWhenSelected(bus);
    }

    public async Task BusPlateShouldntExistWhenCreated(string numberPlate, CancellationToken cancellationToken)
    {
        string numberPlateUpper = numberPlate.ToUpper();
        Bus ? bus = await _busRepository.GetAsync(
            predicate: b => b.NumberPlate == numberPlateUpper,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        
        if(bus != null)
            await throwBusinessException(BusesBusinessMessages.BusNumberPlateExistsWhenCreated);
    }



    public async Task BusPlateShouldExistWhenSelected(string numberPlate, CancellationToken cancellationToken)
    {
        string numberPlateUpper = numberPlate.ToUpper();
        Bus? bus = await _busRepository.GetAsync(
            predicate: b => b.NumberPlate == numberPlateUpper,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (bus == null)
            await throwBusinessException(BusesBusinessMessages.BusNumberPlateNotExistsWhenSelected);
    }
}