using System;
using System.Collections.Generic;

namespace BikeStore.Infrastructure.Persistence.Entities;

public partial class Project
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
