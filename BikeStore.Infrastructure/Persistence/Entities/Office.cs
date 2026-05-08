using System;
using System.Collections.Generic;

namespace BikeStore.Infrastructure.Persistence.Entities;

public partial class Office
{
    public int OfficeId { get; set; }

    public string OfficeName { get; set; } = null!;

    public string OfficeAddress { get; set; } = null!;

    public string? Phone { get; set; }
}
