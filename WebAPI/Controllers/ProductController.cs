using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
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

        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
        {
            var products = _productService.SearchByName(name);

            if (products == null || !products.Any())
            {
                return NotFound($"No products found for name: {name}");
            }

            return Ok(products);
        }

        [HttpGet("status/{status}")]
        public IActionResult GetProductByStatus(int status)
        {
            var products = _productService.GetProductsByStatus(status);
            if (products == null || !products.Any())
            {
                return NotFound($"No products found for status: {status}");
            }

            return Ok(products);
        }

        [HttpGet("Acategories/{categoryId}")]
        public IActionResult GetActiveProductsByCategory(int categoryId)
        {
            var products = _productService.GetActiveProductsByCategory(categoryId);

            if (products == null || !products.Any())
            {
                return NotFound($"No Active products found for category: {categoryId}");
            }

            return Ok(products);
        }
        [HttpGet("DEAcategories/{categoryId}")]
        public IActionResult GetDeActiveProductsByCategory(int categoryId)
        {
            var products = _productService.GetDeActiveProductsByCategory(categoryId);

            if (products == null || !products.Any())
            {
                return NotFound($"No De-active products found for category: {categoryId}");
            }

            return Ok(products);
        }

        [HttpGet("{productId}")]
        public IActionResult GetProductById(int productId)
        {
            var product = _productService.GetProductById(productId);

            if (product == null)
            {
                return NotFound($"No product found for id: {productId}");
            }

            return Ok(product);
        }
    }
}
