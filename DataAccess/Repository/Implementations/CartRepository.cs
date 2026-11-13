using DataAccess.Data;
using DataAccess.Models;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.Implementations
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Cart cart)
        {
            await _context.Cart.AddAsync(cart);
            await _context.SaveChangesAsync();
            return (true);
        }

        public async Task<bool> ClearCartAsync(string UserId)
        {
            var items = _context.Cart.Where(e => e.UserId == UserId);
            if (!items.Any())
                return (false);
            _context.Cart.RemoveRange(items);
            await _context.SaveChangesAsync();
            return (true);
        }

        public async Task DeleteAsync(Cart cart)
        {
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cart>> GetAsync(string UserId)
        {
            var data = await _context.Cart
                .Where(e => e.UserId == UserId)
                .ToListAsync();
            return (data);
        }

        public async Task SaveChangesInDatabaseAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
