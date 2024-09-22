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
        public IActionResult GetUserCartItems(int userID)
        {
            var CartItems = _cartService.GetUserCartItems(userID);
            return Ok(CartItems);
        }
    }
}
