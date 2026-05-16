using BikeStore.Domain.DTOs;
using BikeStore.Domain.Interfaces.Products;
using BikeStore.Infrastructure.Persistence.DbContext;
using BikeStore.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.Infrastructure.Repositories
{

    /// <summary>
    /// It is a repository class for the Product entity. It implements the IProducts interface and inherits from the Repository base class. It uses the BikeDbContext to access the database and perform CRUD operations on the Product entity. It also maps the Product entity to the ProductDto data transfer object for returning data to the service layer.
    /// </summary>
    /// <param name="dbContext"></param>
    internal class ProductRepository(BikeDbContext dbContext)
        : Repository<Product>(dbContext), IProducts
    {
        public async Task<IEnumerable<BrandDto>> GetBrandsAsync(string? search, CancellationToken cancellationToken)
        {
            var query = dbContext.Brands.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(c => c.BrandName.Contains(search));
            }

            var result = await query
                .Select(b => new BrandDto
                (
                    b.BrandId,
                    b.BrandName,
                    null,
                    b.Products.Count
                )).ToListAsync(cancellationToken);

            return result;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync(string? search, CancellationToken cancellationToken)
        {
            var query = dbContext.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(c => c.CategoryName.Contains(search));
            }

            var result = await query
                .Select(c => new CategoryDto
                {
                    CategoryId = c.CategoryId,
                    Name = c.CategoryName,
                    ProductCount = c.Products.Count
                }).ToListAsync(cancellationToken);

            return result;
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await dbContext.Products
                .Include(x => x.Stocks)
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .FirstOrDefaultAsync(x => x.ProductId == id, cancellationToken);

            if (product == null)
            {
                return null;
            }

            return new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.ProductName,
                Description = product.Description,
                Price = product.ListPrice,
                Stock = product.Stocks.Sum(x => x.Quantity) ?? 0,  
                Categoty = product.Category.CategoryName,
                Brand = product.Brand.BrandName,
                ModelYear = product.ModelYear,
                AverageRating = product.AverageRating,
                TotalRatings = product.TotalRatings

            };
        }

        public Task<IEnumerable<ProductReview>> GetProductReviewsAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync(string? search, CancellationToken cancellationToken)
        {
            var query = dbContext.Products
                .Include(x => x.Stocks)
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .AsQueryable();

            var products = string.IsNullOrWhiteSpace(search)
                ? query
                : query.Where(p => p.ProductName.Contains(search) || ( p.Description != null && p.Description.Contains(search)));
             
            return await products
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    Name = p.ProductName,
                    Description = p.Description,
                    Price = p.ListPrice,
                    Stock = p.Stocks.Sum(x => x.Quantity) ?? 0,
                    Categoty = p.Category.CategoryName,
                    Brand = p.Brand.BrandName,
                    ModelYear= p.ModelYear,
                    AverageRating = p.AverageRating,
                    TotalRatings = p.TotalRatings
                })
                .ToListAsync(cancellationToken);
        }



    }
}
