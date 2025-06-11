using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PersonelRepository : EfRepositoryBase<Personel, int, BaseDbContext>, IPersonelRepository
{
    public PersonelRepository(BaseDbContext context) : base(context)
    {
    }
}