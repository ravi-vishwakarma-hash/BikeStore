using BikeStore.Domain.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Infrastructure.Service.Product
{
    /// <summary>
    /// Provides methods for retrieving product information asynchronously from a data source.
    /// </summary>
    /// <param name="products">The data access abstraction used to retrieve product information. Cannot be null.</param>
    public class ProductService (IProducts products)
    {
 
        /// <summary>
        /// This method retrieves a list of products asynchronously by calling the GetProductsAsync method from the IProducts interface. It returns an IEnumerable of ProductDto objects, which represent the data transfer objects for products. The method is designed to be used in scenarios where you need to fetch product information from a data source, such as a database or an API, without blocking the calling thread.
        /// </summary>
        /// <returns>
        /// An IEnumerable of ProductDto objects representing the products retrieved from the data source.
        /// </returns>
        public async Task<IEnumerable<Domain.DTOs.ProductDto>> GetProductsAsync()
        {
            return await products.GetProductsAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to retrieve. Must be a positive integer.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see
        /// cref="Domain.DTOs.ProductDto"/> representing the product if found; otherwise, <see langword="null"/>.</returns>
        public async Task<Domain.DTOs.ProductDto?> GetProductByIdAsync(int id)
        {
            return await products.GetProductByIdAsync(id);
        }

    }
}
