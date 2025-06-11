using Application.Features.BusServices.Constants;
using Application.Features.BusServices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BusServices.Constants.BusServicesOperationClaims;

namespace Application.Features.BusServices.Queries.GetById;

public class GetByIdBusServiceQuery : IRequest<GetByIdBusServiceResponse>
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBusServiceQueryHandler : IRequestHandler<GetByIdBusServiceQuery, GetByIdBusServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBusServiceRepository _busServiceRepository;
        private readonly BusServiceBusinessRules _busServiceBusinessRules;

        public GetByIdBusServiceQueryHandler(IMapper mapper, IBusServiceRepository busServiceRepository, BusServiceBusinessRules busServiceBusinessRules)
        {
            _mapper = mapper;
            _busServiceRepository = busServiceRepository;
            _busServiceBusinessRules = busServiceBusinessRules;
        }

        public async Task<GetByIdBusServiceResponse> Handle(GetByIdBusServiceQuery request, CancellationToken cancellationToken)
        {
            BusService? busService = await _busServiceRepository.GetAsync(predicate: bs => bs.Id == request.Id, cancellationToken: cancellationToken);
            await _busServiceBusinessRules.BusServiceShouldExistWhenSelected(busService);

            GetByIdBusServiceResponse response = _mapper.Map<GetByIdBusServiceResponse>(busService);
            return response;
        }
    }
}