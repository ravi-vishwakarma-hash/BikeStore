using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Domain.DTOs
{
    public sealed class CategoryDto
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; } 

        public string? Description { get; set; }

        public int ProductCount { get; set; }  
    }
     
}
