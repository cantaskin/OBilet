using Application.Features.Buses.Constants;
using Application.Features.Buses.Rules;
using Application.Features.Personels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Buses.Commands.PersonelAssign;
public class PersonelAssignBusCommand : IRequest<PersonelAssignedBusResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest // ISecuredRequest,
{
    public required string NumberPlate { get; set; }
    public required List<int> PersonelIds { get; set; }

    //Personel için buraya bir bölüm ayrılabilir belki ya da personeli kaydetip burada update kısmında yapılabilir. 
    public string[] Roles => [BusesOperationClaims.Admin, BusesOperationClaims.Write, BusesOperationClaims.Create];
    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBuses"];

    public class PersonelAssignBusCommandHandler : IRequestHandler<PersonelAssignBusCommand, PersonelAssignedBusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBusRepository _busRepository;
        private readonly IPersonelRepository _personelRepository;
        private readonly PersonelBusinessRules _personelBusinessRules;
        private readonly BusBusinessRules _busBusinessRules;

        public PersonelAssignBusCommandHandler(IMapper mapper, IBusRepository busRepository,
                                       BusBusinessRules busBusinessRules,IPersonelRepository personelRepository, PersonelBusinessRules personelBusinessRules)
        {
            _mapper = mapper;
            _busRepository = busRepository;
            _busBusinessRules = busBusinessRules;
            _personelRepository = personelRepository;
            _personelBusinessRules = personelBusinessRules;
        }

        public async Task<PersonelAssignedBusResponse> Handle(PersonelAssignBusCommand request, CancellationToken cancellationToken)
        {
            
            request.NumberPlate = request.NumberPlate.ToUpper();


            Bus? bus = await _busRepository.GetAsync(b => b.NumberPlate == request.NumberPlate, cancellationToken: cancellationToken);
            await _busBusinessRules.BusShouldExistWhenSelected(bus);


            List<Personel> personList = new List<Personel>();
            foreach (int personId in request.PersonelIds)
            {

                await _personelBusinessRules.PersonelIdShouldExistWhenSelected(personId, cancellationToken); 
                Personel? person = await _personelRepository.GetAsync(p => p.Id == personId, cancellationToken: cancellationToken);

                personList.Add(person!);
            }


            bus!.PersonelList = personList;


            await _busRepository.UpdateAsync(bus!, cancellationToken);


            PersonelAssignedBusResponse response = _mapper.Map<PersonelAssignedBusResponse>(bus);
            return response;
        }
    }
}