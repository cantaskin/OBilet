using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Bus : Entity<int>
{
    public string NumberPlate { get; set; }
    public int SeatCount { get; set; }
    public bool HasOneSeat { get; set; }
    public int DoorGapRowIndex { get; set; }
    public int DoorGapSize { get; set; }
    public int Column { get; set; }
    public int Row { get; set; }
    public List<Personel> PersonelList { get; set; } = new List<Personel>();
    public List<BusService> BusServices { get; set; } = new List<BusService>();

    //Otobüs türüne göre Seatler değişebilir. Yani 2+1 mi ? 2+2 mi olarak çalışması lazım?
    public List<Seat> Seats { get; set; } = new();
}
