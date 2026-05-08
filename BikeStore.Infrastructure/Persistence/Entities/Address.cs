using System;
using System.Collections.Generic;

namespace BikeStore.Infrastructure.Persistence.Entities;

public partial class Address
{
    public int AddressId { get; set; }

    public string Street { get; set; } = null!;

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zipcode { get; set; }
}
