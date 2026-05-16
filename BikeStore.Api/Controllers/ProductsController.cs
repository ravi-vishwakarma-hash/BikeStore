using BikeStore.Domain.DTOs;
using BikeStore.Infrastructure.Service.Product;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ProductService productService) : ControllerBase
    {

         

        [HttpGet]
        [ProducesResponseType<IEnumerable<ProductDto>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProducts([FromQuery] string? search, CancellationToken cancellationToken)
        {
            var products = await productService.GetProductsAsync(search, cancellationToken);
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType<ProductDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductById(int id, CancellationToken cancellationToken)
        {
            var product = await productService.GetProductByIdAsync(id, cancellationToken);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [HttpGet("categories")]
        [ProducesResponseType<IEnumerable<CategoryDto>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCategories([FromQuery] string? search, CancellationToken cancellationToken)
        {
            var categories = await productService.GetCategoriesAsync(search, cancellationToken);
            return Ok(categories);
        }


        [HttpGet("brands")]
        [ProducesResponseType<IEnumerable<BrandDto>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBrands([FromQuery] string? search, CancellationToken cancellationToken)
        {
            var brands = await productService.GetBrandsAsync(search, cancellationToken);
            return Ok(brands);

        }
    }
}
