using Application.Features.BusServices.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.BusServices.Rules;

public class BusServiceBusinessRules : BaseBusinessRules
{
    private readonly IBusServiceRepository _busServiceRepository;
    private readonly ILocalizationService _localizationService;

    public BusServiceBusinessRules(IBusServiceRepository busServiceRepository, ILocalizationService localizationService)
    {
        _busServiceRepository = busServiceRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BusServicesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BusServiceShouldExistWhenSelected(BusService? busService)
    {
        if (busService == null)
            await throwBusinessException(BusServicesBusinessMessages.BusServiceNotExists);
    }

    public async Task NoBusServiceCreated(List<BusService> busServices)
    {
        if (busServices.Count == 0)
            await throwBusinessException(BusServicesBusinessMessages.NoBusServiceCreated);
    }

    public async Task BusServiceIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        BusService? busService = await _busServiceRepository.GetAsync(
            predicate: bs => bs.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BusServiceShouldExistWhenSelected(busService);
    }

    public async Task BusServiceStartTimeShouldBeBeforeFinishTime(DateTime startTime, DateTime finishTime)
    {
        if (startTime >= finishTime)
            await throwBusinessException(BusServicesBusinessMessages.BusServiceStartTimeShouldBeBeforeFinishTime);
    }

    public async Task BusServiceStationsShouldGreaterThanOne(List<int> stationIds)
    {
        if (stationIds.Count < 2)
            await throwBusinessException(BusServicesBusinessMessages.BusServiceStationsShouldGreaterThanOne);
    }


}