using System;
using System.Collections.Generic;

namespace BikeStore.Infrastructure.Persistence.Entities;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public string Comment { get; set; } = null!;
}
