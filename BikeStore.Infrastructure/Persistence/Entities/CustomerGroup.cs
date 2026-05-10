using System;
using System.Collections.Generic;

namespace BikeStore.Infrastructure.Persistence.Entities;

public partial class CustomerGroup
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;
}
