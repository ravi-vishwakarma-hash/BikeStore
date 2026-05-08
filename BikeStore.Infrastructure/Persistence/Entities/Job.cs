using System;
using System.Collections.Generic;

namespace BikeStore.Infrastructure.Persistence.Entities;

public partial class Job
{
    public int JobId { get; set; }

    public int CustomerId { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }
}
