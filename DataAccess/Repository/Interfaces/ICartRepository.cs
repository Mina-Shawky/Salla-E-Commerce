using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.Interfaces
{
    public interface ICartRepository
    {
        public Task<List<Cart>> GetAsync(string UserId);
        public Task<bool> AddAsync(Cart cart);
        public Task DeleteAsync(Cart cart);
        public Task<bool> ClearCartAsync(string UserId);
        public Task SaveChangesInDatabaseAsync();

    }
}
