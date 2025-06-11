using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BusServiceStation : Entity<int>
{
    public int BusServiceRootId { get; set; }
    public int BusServiceId { get; set; }
    public BusService BusService { get; set; }

    public int StationId { get; set; }
    public Station Station { get; set; }

    public int Order { get; set; } 
}
