using Application.Features.Buses.Constants;
using Application.Features.Buses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Buses.Constants.BusesOperationClaims;

namespace Application.Features.Buses.Commands.Update;

public class UpdateBusCommand : IRequest<UpdatedBusResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string NumberPlate { get; set; }
    public required int SeatCount { get; set; }
    public required bool HasOneSeat { get; set; }

    public string[] Roles => [Admin, Write, BusesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBuses"];

    public class UpdateBusCommandHandler : IRequestHandler<UpdateBusCommand, UpdatedBusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBusRepository _busRepository;
        private readonly BusBusinessRules _busBusinessRules;

        public UpdateBusCommandHandler(IMapper mapper, IBusRepository busRepository,
                                         BusBusinessRules busBusinessRules)
        {
            _mapper = mapper;
            _busRepository = busRepository;
            _busBusinessRules = busBusinessRules;
        }

        public async Task<UpdatedBusResponse> Handle(UpdateBusCommand request, CancellationToken cancellationToken)
        {
            Bus? bus = await _busRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _busBusinessRules.BusShouldExistWhenSelected(bus);
            bus = _mapper.Map(request, bus);

            await _busRepository.UpdateAsync(bus!);

            UpdatedBusResponse response = _mapper.Map<UpdatedBusResponse>(bus);
            return response;
        }
    }
}