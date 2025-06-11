using Application.Features.BusServices.Constants;
using Application.Features.BusServices.Rules;
using Application.Features.BusServiceStations.Rules;
using Application.Services.BusServiceStations;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.BusServices.Constants.BusServicesOperationClaims;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;

namespace Application.Features.BusServices.Commands.Update;

public class UpdateBusServiceCommand : IRequest<UpdatedBusServiceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{

    //Bütün hepsinin starttime, finishtime'ý deðiþtirilebilir ama diðerlerine girmemesi lazým.
    public int Id { get; set; }
    public required DateTime StartTime { get; set; }
    public required DateTime FinishTime { get; set; }
    public required decimal BasePrice { get; set; }
    public string[] Roles => [Admin, Write, BusServicesOperationClaims.Update];
    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBusServices"];

    public class UpdateBusServiceCommandHandler : IRequestHandler<UpdateBusServiceCommand, UpdatedBusServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBusServiceRepository _busServiceRepository;
        private readonly BusServiceBusinessRules _busServiceBusinessRules;
        private readonly BusServiceStationBusinessRules _busServiceStationBusinessRules;
        private readonly IBusServiceStationRepository _busServiceStationRepository;
        private readonly IBusServiceStationService _busServiceStationService;

        public UpdateBusServiceCommandHandler(IMapper mapper, IBusServiceRepository busServiceRepository,
                                         BusServiceBusinessRules busServiceBusinessRules, IBusServiceStationRepository busServiceStationRepository, IBusServiceStationService busServiceStationService, BusServiceStationBusinessRules busServiceStationBusinessRules)
        {
            _mapper = mapper;
            _busServiceRepository = busServiceRepository;
            _busServiceBusinessRules = busServiceBusinessRules;
            _busServiceStationRepository = busServiceStationRepository;
            _busServiceStationService = busServiceStationService;
            _busServiceStationBusinessRules = busServiceStationBusinessRules;
        }

        public async Task<UpdatedBusServiceResponse> Handle(UpdateBusServiceCommand request, CancellationToken cancellationToken)
        {
            BusService? busService = await _busServiceRepository.GetAsync(predicate: bs => bs.Id == request.Id, cancellationToken: cancellationToken);
            await _busServiceBusinessRules.BusServiceShouldExistWhenSelected(busService);

            var fromStation = await _busServiceStationRepository.GetFirstByOrder(busService!.Id);
            await _busServiceStationBusinessRules.BusServiceStationShouldExistWhenSelected(fromStation);

            var toStation = await _busServiceStationRepository.GetLastByOrder(busService!.Id);
            await _busServiceStationBusinessRules.BusServiceStationShouldExistWhenSelected(toStation);

            
            var busServices  = await _busServiceRepository.GetListAsync(bs => bs.RootId == busService!.RootId, cancellationToken: cancellationToken, index: 0, size: Int32.MaxValue);
            

            IList<BusService> busServicesList = new List<BusService>();
            if (busServices != null && busServices.Items != null)
            {
                busServicesList = busServices.Items.ToList();
            }
            if (busServices == null || busServices.Items.Count == 0)
            {
                await _busServiceBusinessRules.NoBusServiceCreated(busServices.Items.ToList());
            }


            Dictionary<int, Dictionary<int, int>> busServiceStationOrders = new();
                
            Dictionary<int, int> ourStationIdOrderDictionary = await _busServiceStationService.GetStationIdOrderDictionary(busService!.Id, cancellationToken);

            //Bunun var olup olmadýðýný kontrol etmem lazým.

            var startOrder = ourStationIdOrderDictionary[fromStation.Id];
            var finishOrder = ourStationIdOrderDictionary[toStation.Id];


            foreach (var item in busServicesList)
            {
                
                Dictionary<int, int> rootStationIdOrderDictionary = await _busServiceStationService.GetStationIdOrderDictionary(item.Id, cancellationToken);


                if(rootStationIdOrderDictionary.Count == 0){
                    continue;
                }

                if (!rootStationIdOrderDictionary.ContainsKey(fromStation.Id) || !rootStationIdOrderDictionary.ContainsKey(toStation.Id))
                    continue;

                var startItemOrder = rootStationIdOrderDictionary[fromStation.Id];
                var finishItemOrder = rootStationIdOrderDictionary[toStation.Id];

                if (startItemOrder < finishOrder && finishItemOrder > startOrder)
                {
                    throw new BusinessException("Bus Service conflict error");
                    /*bu durumu tekrar düþünmem lazým. 4 durum var hepsini kontrol etmem lazým benden büyük bir sefer de olabilir benden ufak da olabilir.
                     Veya order olarak daha büyük baþladýysa o daha eski olmasý gerekir. Daha sonraysa sonra olmasý lazým falan.*/
                }

                if (startItemOrder < finishOrder && finishItemOrder < startOrder && startOrder < startItemOrder)
                {
                    throw new BusinessException("Bus Service conflict error");
                }


            }

            busService = _mapper.Map(request, busService);

            await _busServiceRepository.UpdateAsync(busService!, cancellationToken);

            UpdatedBusServiceResponse response = _mapper.Map<UpdatedBusServiceResponse>(busService);
            return response;
        }
    }
}