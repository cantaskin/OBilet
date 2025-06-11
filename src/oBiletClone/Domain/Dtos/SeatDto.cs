using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos;
public class SeatDto
{
    public int BusId { get; set; }
    public int LocalSeatId { get; set; }

    public int? LeftSeatId { get; set; }
    public int? RightSeatId { get; set; }
    public int? TopSeatId { get; set; }
    public int? BottomSeatId { get; set; }

}
