using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class BusService : Entity<int>
{
    public int RootId { get; set; }
    public string Name { get; set; }
    public int BusId { get; set; }
    public Bus Bus { get; set; }
    public List<BusServiceStation> BusServiceStations { get; set; } = new List<BusServiceStation>() {};
    public DateTime? StartTime { get; set; }
    public DateTime? FinishTime { get; set; }
    public int? DurationInMinutes =>
        (StartTime.HasValue && FinishTime.HasValue)
            ? (int?)(FinishTime.Value - StartTime.Value).TotalMinutes
            : null;
    public decimal? BasePrice { get; set; }
    public List<Ticket> Tickets { get; set; }
    public bool IsSellable { get; set; } = false; 

}

