using Application.Features.Buses.Constants;
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

namespace Application.Features.Buses.Commands.Delete;

public class DeleteBusCommand : IRequest<DeletedBusResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, BusesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBuses"];

    public class DeleteBusCommandHandler : IRequestHandler<DeleteBusCommand, DeletedBusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBusRepository _busRepository;
        private readonly BusBusinessRules _busBusinessRules;

        public DeleteBusCommandHandler(IMapper mapper, IBusRepository busRepository,
                                         BusBusinessRules busBusinessRules)
        {
            _mapper = mapper;
            _busRepository = busRepository;
            _busBusinessRules = busBusinessRules;
        }

        public async Task<DeletedBusResponse> Handle(DeleteBusCommand request, CancellationToken cancellationToken)
        {
            Bus? bus = await _busRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _busBusinessRules.BusShouldExistWhenSelected(bus);

            await _busRepository.DeleteAsync(bus!);

            DeletedBusResponse response = _mapper.Map<DeletedBusResponse>(bus);
            return response;
        }
    }
}