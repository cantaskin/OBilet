using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPersonelRepository : IAsyncRepository<Personel, int>, IRepository<Personel, int>
{
}