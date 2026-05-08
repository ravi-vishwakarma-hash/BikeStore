using System;
using System.Collections.Generic;

namespace BikeStore.Infrastructure.Persistence.Entities;

public partial class ProductJson
{
    public int Id { get; set; }

    public string? Info { get; set; }
}
