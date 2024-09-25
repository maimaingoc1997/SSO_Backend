using DataAccessLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICartService
    {
        List<CartWithProductDTO> GetUserCartItems(int userId);
        List<CartWithProductDTO> GetUserWishlistItems(int userId);

        void AddToCart(CartWithProductDTO cartItem, int userId);
    }
}
