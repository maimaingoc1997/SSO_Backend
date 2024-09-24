using DataAccessLayer.Models;
using DataAccessLayer.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Where(c => c.UserId == userId) // Filter by UserId
                .Include(c => c.Product)        // Include the related Product
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
    }
}
