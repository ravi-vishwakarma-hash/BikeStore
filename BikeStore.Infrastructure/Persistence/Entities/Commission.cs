using System;
using System.Collections.Generic;

namespace BikeStore.Infrastructure.Persistence.Entities;

public partial class Commission
{
    public int StaffId { get; set; }

    public int? TargetId { get; set; }

    public decimal BaseAmount { get; set; }

    public decimal Commission1 { get; set; }

    public virtual Staff Staff { get; set; } = null!;

    public virtual Target? Target { get; set; }
}
