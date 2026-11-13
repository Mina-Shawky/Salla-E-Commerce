using BusinessLogic.Services.Interfaces;
using DataAccess.DTOs;
using DataAccess.DTOs.Request;
using DataAccess.DTOs.Response;
using DataAccess.Models;
using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<bool> AddToCartAsync(CartRequestDTO Cart, string UserId)
        {
            var item = new Cart
            {
                Count = 1,
                UserId = UserId,
                ProductId = Cart.ProductId
            };
            return await _cartRepository.AddAsync(item);
        }

        public async Task<bool> ClearCartAsync(string userId)
        {
            var result = await _cartRepository.ClearCartAsync(userId);
            if (result is true) 
                return true;
            return false;

        }

        public async Task<bool> DeleteCartAsync(string UserId)
        {
            var UserCart = await _cartRepository.GetAsync(UserId);
            if (UserCart is null)
                return false;
            foreach (var cart in UserCart)
            {
               await _cartRepository.DeleteAsync(cart);

            }
            await _cartRepository.SaveChangesInDatabaseAsync();

            return true;
        }

        public async Task<CartDTO> GetUserCartAsync(string UserId)
        {
            var UserCart = await _cartRepository.GetAsync(UserId);
            var response = new CartDTO()
            {
                Items = UserCart.Select(c => new CartResponseDTO()
                {
                    ProductId = c.ProductId,
                    ProductName = c.Product.Name,
                    Count = c.Count,
                    Price = c.Product.Price
                }
                ).ToList()
            };
            return response;
        }
    }
}
