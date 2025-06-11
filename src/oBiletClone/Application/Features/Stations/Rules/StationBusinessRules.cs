using Application.Features.Stations.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Stations.Rules;

public class StationBusinessRules : BaseBusinessRules
{
    private readonly IStationRepository _stationRepository;
    private readonly ILocalizationService _localizationService;

    public StationBusinessRules(IStationRepository stationRepository, ILocalizationService localizationService)
    {
        _stationRepository = stationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, StationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task StationShouldExistWhenSelected(Station? station)
    {
        if (station == null)
            await throwBusinessException(StationsBusinessMessages.StationNotExists);
    }

    public async Task StationIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Station? station = await _stationRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StationShouldExistWhenSelected(station);
    }
}