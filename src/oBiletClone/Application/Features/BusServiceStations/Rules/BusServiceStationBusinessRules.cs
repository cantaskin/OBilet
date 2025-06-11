using Application.Features.BusServiceStations.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.BusServiceStations.Rules;

public class BusServiceStationBusinessRules : BaseBusinessRules
{
    private readonly IBusServiceStationRepository _busServiceStationRepository;
    private readonly ILocalizationService _localizationService;

    public BusServiceStationBusinessRules(IBusServiceStationRepository busServiceStationRepository, ILocalizationService localizationService)
    {
        _busServiceStationRepository = busServiceStationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BusServiceStationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BusServiceStationShouldExistWhenSelected(BusServiceStation? busServiceStation)
    {
        if (busServiceStation == null)
            await throwBusinessException(BusServiceStationsBusinessMessages.BusServiceStationNotExists);
    }

    public async Task BusServiceStationIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        BusServiceStation? busServiceStation = await _busServiceStationRepository.GetAsync(
            predicate: bss => bss.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BusServiceStationShouldExistWhenSelected(busServiceStation);
    }



}