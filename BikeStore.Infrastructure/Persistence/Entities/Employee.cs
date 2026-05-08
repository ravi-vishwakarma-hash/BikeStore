using System;
using System.Collections.Generic;

namespace BikeStore.Infrastructure.Persistence.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string Fullname { get; set; } = null!;
}
