using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Domain.DTOs
{
    //public sealed class BrandDto
    //{
    //    public int Id { get; set; }
    //    public string? Name { get; set; }

    //    public string? Description { get; set; }

    //    public int ProductCount { get; set; } = 0;
         
    //}


    public record BrandDto(
        int Id,
        string? Name,
        string? Description,
        int ProductCount
    );

}
