using System;
using System.Collections.Generic;

namespace BikeStore.Infrastructure.Persistence.Entities;

public partial class ProductRating
{
    public long Id { get; set; }

    public int ProductId { get; set; }

    public int CustomerId { get; set; }

    public decimal Rating { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
