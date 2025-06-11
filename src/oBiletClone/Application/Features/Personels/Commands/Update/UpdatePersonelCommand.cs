using Application.Features.Personels.Constants;
using Application.Features.Personels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Personels.Constants.PersonelsOperationClaims;

namespace Application.Features.Personels.Commands.Update;

public class UpdatePersonelCommand : IRequest<UpdatedPersonelResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string NationalId { get; set; }
    public required bool IsMale { get; set; }

    public string[] Roles => [Admin, Write, PersonelsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPersonels"];

    public class UpdatePersonelCommandHandler : IRequestHandler<UpdatePersonelCommand, UpdatedPersonelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPersonelRepository _personelRepository;
        private readonly PersonelBusinessRules _personelBusinessRules;

        public UpdatePersonelCommandHandler(IMapper mapper, IPersonelRepository personelRepository,
                                         PersonelBusinessRules personelBusinessRules)
        {
            _mapper = mapper;
            _personelRepository = personelRepository;
            _personelBusinessRules = personelBusinessRules;
        }

        public async Task<UpdatedPersonelResponse> Handle(UpdatePersonelCommand request, CancellationToken cancellationToken)
        {
            Personel? personel = await _personelRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _personelBusinessRules.PersonelShouldExistWhenSelected(personel);
            personel = _mapper.Map(request, personel);

            await _personelRepository.UpdateAsync(personel!);

            UpdatedPersonelResponse response = _mapper.Map<UpdatedPersonelResponse>(personel);
            return response;
        }
    }
}