using BikeStore.Infrastructure.Service.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ProductService productService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            var products = await productService.GetProductsAsync(cancellationToken);
            return Ok(products);
        }

        [HttpGet("{id:int}")]
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
        public async Task<IActionResult> GetCategories([FromQuery] string? search, CancellationToken cancellationToken)
        {
            var categories = await productService.GetCategoriesAsync(search, cancellationToken);

            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }


        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands([FromQuery] string? search, CancellationToken cancellationToken)
        {
            var brands = await productService.GetBrandsAsync(search, cancellationToken);
            if (brands == null)
            {
                return NotFound();
            }
            return Ok(brands);

        }
    }
}
