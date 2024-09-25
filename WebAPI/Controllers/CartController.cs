using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models.DTOs;
using DataAccessLayer.Repositories;
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

        [HttpGet("user-cart")]
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

        [HttpGet("user-wishlist")]
        public IActionResult GetWishListByUserID()
        {
            var userId = Request.Headers["userId"].FirstOrDefault();

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID is required");
            }

            var wistlist = _cartService.GetUserWishlistItems(int.Parse(userId));
            return Ok(wistlist);
        }

        [HttpPost("add")]
        public IActionResult AddToCart(CartWithProductDTO cartItem)
        {
            var userId = Request.Headers["userId"].FirstOrDefault();

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID is required");
            }

            if (cartItem == null)
            {
                return BadRequest("Invalid item.");
            }

            _cartService.AddToCart(cartItem, int.Parse(userId));

            return Ok(new { message = "Item added to cart successfully." });
        }
        [HttpPost("remove")]
        public IActionResult Remove(CartWithProductDTO cartItem)
        {
            var userId = Request.Headers["userId"].FirstOrDefault();

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID is required");
            }

            if (cartItem == null)
            {
                return BadRequest("Invalid item.");
            }

            _cartService.RemoveFromCart(cartItem, int.Parse(userId));

            return Ok(new { message = "Item remove successfully." });
        }
        [HttpPost("addWishList")]
        public IActionResult AddToWishList(CartWithProductDTO cartItem)
        {
            var userId = Request.Headers["userId"].FirstOrDefault();

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID is required");
            }

            if (cartItem == null)
            {
                return BadRequest("Invalid item.");
            }

            _cartService.AddToWishList(cartItem, int.Parse(userId));

            return Ok(new { message = "Item added to wishlist successfully." });
        }
    }
}
