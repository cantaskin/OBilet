using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Station : Entity<int>
{
    public string Name { get; set; }

    public List<Ticket> FromTickets { get; set; } = new();
    public List<Ticket> ToTickets { get; set; } = new();
    public List<BusServiceStation> BusServiceStation { get; set; } = new List<BusServiceStation>();
}
