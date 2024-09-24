using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult GetCartByUserID()
        {
            var userId = Request.Headers["userId"].FirstOrDefault();

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID is required");
            }

            var carts = _cartService.GetUserCartItems(int.Parse(userId)); // Pass userId to service
            return Ok(carts);
        }

    }
}
