using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Domain.DTOs
{
    public sealed class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } 
        public decimal Price { get; set; }
        public int Stock { get; set; } 

        public string Category { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public int? ModelYear { get; set; }
        public decimal AverageRating { get; set; }
        public int TotalRatings { get; set; }
    }
}
