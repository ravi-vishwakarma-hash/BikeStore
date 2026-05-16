using BikeStore.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Domain.Interfaces.Products
{
    public interface IProducts
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync(string? search, CancellationToken cancellationToken);
        Task<ProductDto?> GetProductByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync(string? search, CancellationToken cancellationToken);
        Task<IEnumerable<BrandDto>> GetBrandsAsync(string? search, CancellationToken cancellationToken);

        Task<IEnumerable<ProductReview>> GetProductReviewsAsync(int id, CancellationToken cancellationToken);


    }
}
