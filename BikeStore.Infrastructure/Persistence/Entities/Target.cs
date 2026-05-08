using System;
using System.Collections.Generic;

namespace BikeStore.Infrastructure.Persistence.Entities;

public partial class Target
{
    public int TargetId { get; set; }

    public decimal Percentage { get; set; }

    public virtual ICollection<Commission> Commissions { get; set; } = new List<Commission>();
}
