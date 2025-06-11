using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITicketRepository : IAsyncRepository<Ticket, int>, IRepository<Ticket, int>
{
}