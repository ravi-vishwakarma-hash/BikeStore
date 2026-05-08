using System;
using System.Collections.Generic;

namespace BikeStore.Infrastructure.Persistence.Entities;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}
