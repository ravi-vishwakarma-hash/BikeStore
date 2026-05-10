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
        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await dbContext.Products.FindAsync(id);
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
                Stock = 500 // Assuming a fixed stock value for demonstration purposes
            };


        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            return await dbContext.Products
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    Name = p.ProductName,
                    Description = p.Description,
                    Price = p.ListPrice,
                    Stock = 500 // Assuming a fixed stock value for demonstration purposes
                })
                .ToListAsync();
        }
    }
}
