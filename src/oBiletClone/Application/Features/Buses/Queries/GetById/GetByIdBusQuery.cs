using Application.Features.Buses.Constants;
using Application.Features.Buses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.Buses.Constants.BusesOperationClaims;

namespace Application.Features.Buses.Queries.GetById;

public class GetByIdBusQuery : IRequest<GetByIdBusResponse>
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBusQueryHandler : IRequestHandler<GetByIdBusQuery, GetByIdBusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBusRepository _busRepository;
        private readonly BusBusinessRules _busBusinessRules;

        public GetByIdBusQueryHandler(IMapper mapper, IBusRepository busRepository, BusBusinessRules busBusinessRules)
        {
            _mapper = mapper;
            _busRepository = busRepository;
            _busBusinessRules = busBusinessRules;
        }

        public async Task<GetByIdBusResponse> Handle(GetByIdBusQuery request, CancellationToken cancellationToken)
        {
            Bus? bus = await _busRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken, include: i => i.Include(b => b.PersonelList).Include(b => b.Seats));
            await _busBusinessRules.BusShouldExistWhenSelected(bus);



           foreach (var person in bus!.PersonelList)
           {
               string firstNameSubstring = person.FirstName.Substring(0,2);
               person.FirstName = firstNameSubstring + "****";
               string lastNameSubstring = person.LastName.Substring(0,2);
               person.LastName = lastNameSubstring + "****";
           }

            GetByIdBusResponse response = _mapper.Map<GetByIdBusResponse>(bus);
            return response;
        }
    }
}