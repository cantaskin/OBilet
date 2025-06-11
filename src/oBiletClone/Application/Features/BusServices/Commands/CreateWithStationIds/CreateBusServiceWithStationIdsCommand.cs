using Application.Features.Buses.Rules;
using Application.Features.BusServices.Constants;
using Application.Features.BusServices.Rules;
using Application.Features.Stations.Rules;
using Application.Services.Buses;
using Application.Services.BusServices;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.BusServices.Constants.BusServicesOperationClaims;
using System.Collections.Generic;
using Nest;

namespace Application.Features.BusServices.Commands.CreateWithStationIds;

public class CreateBusServiceWithStationIdsCommand : MediatR.IRequest<CreateBusServiceWithStationIdsResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest // ISecuredRequest,
{
    public required int BusId { get; set; }
    public required List<int> StationIds { get; set; } //Burada sýrasýyla vermek zorundayýz.
    public required DateTime StartTime { get; set; }
    public required DateTime FinishTime { get; set; }
    public string[] Roles => [Admin, Write, BusServicesOperationClaims.Create];
    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBusServices"];

    public class CreateBusServiceCommandHandler : IRequestHandler<CreateBusServiceWithStationIdsCommand, CreateBusServiceWithStationIdsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBusServiceRepository _busServiceRepository;
        private readonly IBusServiceService _busServiceService;
        private readonly BusBusinessRules _busBusinessRules;
        private readonly IBusRepository _busRepository;
        private readonly StationBusinessRules _stationBusinessRules;
        private readonly BusServiceBusinessRules _busServiceBusinessRules;
        private readonly IStationRepository _stationRepository;

        public CreateBusServiceCommandHandler(IMapper mapper, IBusServiceRepository busServiceRepository,
                                         BusServiceBusinessRules busServiceBusinessRules, IBusServiceService busService, IStationRepository stationRepository, StationBusinessRules stationBusinessRules, IBusRepository busRepository, BusBusinessRules busBusinessRules)
        {
            _mapper = mapper;
            _busServiceRepository = busServiceRepository;
            _busServiceBusinessRules = busServiceBusinessRules;
            _busServiceService = busService;
            _stationRepository = stationRepository;
            _stationBusinessRules = stationBusinessRules;
            _busRepository = busRepository;
            _busBusinessRules = busBusinessRules;
        }

        public async Task<CreateBusServiceWithStationIdsResponse> Handle(CreateBusServiceWithStationIdsCommand request, CancellationToken cancellationToken)
        {
            List<BusService> busServices = new List<BusService>();


            var bus = await _busRepository.GetAsync(b => b.Id == request.BusId, cancellationToken: cancellationToken);
            await _busBusinessRules.BusShouldExistWhenSelected(bus);

            await _busServiceBusinessRules.BusServiceStationsShouldGreaterThanOne(request.StationIds);
            await _busServiceBusinessRules.BusServiceStartTimeShouldBeBeforeFinishTime(request.StartTime, request.FinishTime);

            int stationCount = request.StationIds.Count;
            int rootId = 0;
            

            for (int i = 0; i < stationCount; i++)
            {
                for (int j = i + 1; j < stationCount; j++)
                {
                    var stationsList = new List<Station>();
                    List<BusServiceStation> busServiceStations = new List<BusServiceStation>();

                    for (int k = i; k <= j; k++)
                    {
                        var tempStationId = request.StationIds[k];
                            
                        var station = await _stationRepository.GetAsync(p => p.Id == tempStationId, cancellationToken: cancellationToken);
                        await _stationBusinessRules.StationShouldExistWhenSelected(station);
                        
                        stationsList.Add(station!);

                        busServiceStations.Add(new BusServiceStation
                        {
                            Station = station!,
                            StationId = station!.Id,
                            Order = k - i // sýfýrdan baþlayarak sýrayý veriyoruz,
                        });
                    }

                    BusService busService = new BusService()
                    {
                        Name = $"{stationsList[0].Name}-{stationsList.Last().Name
                        } Seferi",
                        BusId = request.BusId,
                        BusServiceStations = busServiceStations,
                    };
                    busServices.Add(busService);
                }
            }

            await _busServiceBusinessRules.NoBusServiceCreated(busServices);

            await _busServiceRepository.AddRangeAsync(busServices, cancellationToken);
            
            rootId = busServices[stationCount - 2].Id; // Ilk sýranýn sonuncusu root olmalý.

            busServices.ForEach(bs =>
            {
                bs.RootId = rootId;

                if(bs.Id == rootId)
                    bs.Name += $" Baþlangýç-Bitiþ Saati: {request.StartTime}-{request.FinishTime}";
                
                bs.BusServiceStations.ForEach(bss =>
                {
                    bss.BusServiceRootId = rootId;
                    bss.BusServiceId = bs.Id;
                });
            });

            await _busServiceRepository.UpdateRangeAsync(busServices, cancellationToken);
            CreateBusServiceWithStationIdsResponse response = _mapper.Map<CreateBusServiceWithStationIdsResponse>(new BusService());
            return response;
        }
    }
}