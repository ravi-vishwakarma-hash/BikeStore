using System;
using System.Collections.Generic;

namespace BikeStore.Infrastructure.Persistence.Entities;

public partial class Visit
{
    public int VisitId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Phone { get; set; }

    public int StoreId { get; set; }

    public DateTime? VisitedAt { get; set; }

    public virtual Store Store { get; set; } = null!;
}
