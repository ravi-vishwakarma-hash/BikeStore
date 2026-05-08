using System;
using System.Collections.Generic;

namespace BikeStore.Infrastructure.Persistence.Entities;

public partial class Promotion
{
    public int PromotionId { get; set; }

    public string PromotionName { get; set; } = null!;

    public decimal? Discount { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly ExpiredDate { get; set; }
}
