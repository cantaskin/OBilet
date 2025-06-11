using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Personel : Entity<int>
{
    public string FirstName { get; set; }
    public string LastName { get;set; }
    public string NationalId { get; set; }
    public bool IsMale { get; set; }
    public List<Bus> Buses { get; set; } = new List<Bus>();
}
