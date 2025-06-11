using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Seat : Entity<int>
{
    public int BusId { get; set; }
    public Bus Bus { get; set; }

    public int LocalSeatId { get; set; }

    //Neighbour Seat But Local Type Yani BusInsideSeatId
    public int? LeftSeatId { get; set; }
    public int? RightSeatId { get; set; }
    public int? TopSeatId { get; set; }
    public int? BottomSeatId { get; set; }
    public List<Ticket> Tickets { get; set; } = new List<Ticket>();

}
