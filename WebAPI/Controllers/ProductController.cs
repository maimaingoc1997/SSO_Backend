using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("categories/{categoryId}")]
        public IActionResult GetProductsByCategory(int categoryId)
        {

            var products = _productService.GetProductByCategory(categoryId);

            if (products == null || !products.Any())
            {
                return NotFound($"No products found for category: {categoryId}");
            }

            return Ok(products);
        }
    }
}
