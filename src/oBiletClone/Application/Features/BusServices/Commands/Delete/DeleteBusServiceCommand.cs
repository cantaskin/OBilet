using Application.Features.BusServices.Constants;
using Application.Features.BusServices.Constants;
using Application.Features.BusServices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.BusServices.Constants.BusServicesOperationClaims;

namespace Application.Features.BusServices.Commands.Delete;

public class DeleteBusServiceCommand : IRequest<DeletedBusServiceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, BusServicesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBusServices"];

    public class DeleteBusServiceCommandHandler : IRequestHandler<DeleteBusServiceCommand, DeletedBusServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBusServiceRepository _busServiceRepository;
        private readonly BusServiceBusinessRules _busServiceBusinessRules;

        public DeleteBusServiceCommandHandler(IMapper mapper, IBusServiceRepository busServiceRepository,
                                         BusServiceBusinessRules busServiceBusinessRules)
        {
            _mapper = mapper;
            _busServiceRepository = busServiceRepository;
            _busServiceBusinessRules = busServiceBusinessRules;
        }

        public async Task<DeletedBusServiceResponse> Handle(DeleteBusServiceCommand request, CancellationToken cancellationToken)
        {
            BusService? busService = await _busServiceRepository.GetAsync(predicate: bs => bs.Id == request.Id, cancellationToken: cancellationToken);
            await _busServiceBusinessRules.BusServiceShouldExistWhenSelected(busService);

            await _busServiceRepository.DeleteAsync(busService!);

            DeletedBusServiceResponse response = _mapper.Map<DeletedBusServiceResponse>(busService);
            return response;
        }
    }
}