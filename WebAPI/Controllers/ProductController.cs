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

        [HttpGet("category/{category}")]
        public IActionResult GetProductsByCategory(string category)
        {
            var products = _productService.GetProductsByCategory(category);

            if (products == null || !products.Any())
            {
                return NotFound($"No products found for category: {category}");
            }

            return Ok(products);
        }
    }
}
