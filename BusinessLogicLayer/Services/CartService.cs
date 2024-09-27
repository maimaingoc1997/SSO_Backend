using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models.DTOs;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CartService : ICartService
    {
        private readonly CartRepository _cartRepository;

        public CartService(CartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public void RemoveFromCart(CartWithProductDTO cartItem, int userId)
        {
            _cartRepository.RemoveFromCart(cartItem, userId); 
        }
        public void AddToCart(CartWithProductDTO cartItem, int userId)
        {
            _cartRepository.AddToCart(cartItem, userId);
        }

        public List<CartWithProductDTO> GetUserCartItems(int userId)
        {
            return _cartRepository.GetUserCartItems(userId);
        }

        public List<CartWithProductDTO> GetUserWishlistItems(int userId)
        {
            return _cartRepository.GetUserWishlistItems(userId);
        }

        public void AddToWishList(CartWithProductDTO cartItem, int userId)
        {
            _cartRepository.AddToWishList(cartItem, userId);
        }
    }
}
