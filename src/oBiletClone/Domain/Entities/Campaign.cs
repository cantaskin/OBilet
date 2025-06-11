using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Campaign : Entity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }

    public decimal DiscountPercentage { get; set; } // Yüzde bazında indirim

    public decimal? DiscountFixedAmount { get; set; } // Sabit tutar indirimi (opsiyonel)

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public bool IsActive => DateTime.Now >= StartDate && DateTime.Now <= EndDate;

}

