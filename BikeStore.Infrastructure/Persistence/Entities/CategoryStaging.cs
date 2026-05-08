using System;
using System.Collections.Generic;

namespace BikeStore.Infrastructure.Persistence.Entities;

public partial class CategoryStaging
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public decimal? Amount { get; set; }
}
