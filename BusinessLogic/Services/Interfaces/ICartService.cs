using DataAccess.DTOs;
using DataAccess.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Interfaces
{
    public interface ICartService
    {
        public Task<bool> AddToCartAsync(CartRequestDTO Cart, string UserId);
        public Task<CartDTO> GetUserCartAsync(string UserId);
        public Task<bool> DeleteCartAsync(string UserId);
        public Task<bool> ClearCartAsync(string userId);
    }
}
