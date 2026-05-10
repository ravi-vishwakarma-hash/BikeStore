using BikeStore.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Domain.Interfaces.Products
{
    public interface IProducts
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int id);
    }
}
