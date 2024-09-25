using DataAccessLayer.Models;
using DataAccessLayer.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataAccessLayer.Repositories
{
    public class CartRepository
    {
        private readonly HmwebsiteContext _context;

        public CartRepository(HmwebsiteContext context)
        {
            _context = context;
        }

        public List<CartWithProductDTO> GetUserCartItems(int userId)
        {
            return _context.Carts
                .Where(c => c.UserId == userId && c.IsWishlist == 0)
                .Include(c => c.Product)
                .Select(c => new CartWithProductDTO
                {
                    CartId = c.Id,
                    ProductId = c.Product.Id,
                    ProductName = c.Product.Name,
                    ProductPrice = c.Product.Price,
                    Image = c.Product.Image,
                    size = c.Product.SizeId,
                    Quantity = c.Quantity,
                    IsWishlist = c.IsWishlist
                })
                .ToList();
        }

        public List<CartWithProductDTO> GetUserWishlistItems(int userId)
        {
            return _context.Carts
                .Where(c => c.UserId == userId && c.IsWishlist == 1)
                .Include(c => c.Product)
                .Select(c => new CartWithProductDTO
                {
                    CartId = c.Id,
                    ProductId = c.Product.Id,
                    ProductName = c.Product.Name,
                    ProductPrice = c.Product.Price,
                    Image = c.Product.Image,
                    size = c.Product.SizeId,
                    Quantity = c.Quantity,
                    IsWishlist = c.IsWishlist
                })
                .ToList();
        }

        public void AddToCart(CartWithProductDTO cartItem, int userId)
        {
            var existingCartItem = _context.Carts
                .FirstOrDefault(c => c.UserId == userId && c.ProductId == cartItem.ProductId);

            if (existingCartItem != null)
            {
                if (existingCartItem.IsWishlist == 1)
                {
                    existingCartItem.IsWishlist = 0;
                }
                else
                {
                    existingCartItem.Quantity += cartItem.Quantity;
                }

            }
            else
            {
                var newCartItem = new Cart
                {
                    UserId = userId,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    IsWishlist = 0
                };

                _context.Carts.Add(newCartItem);
            }

            _context.SaveChanges();
        }
    }
}
