using DataAccess.Data;
using DataAccess.Models;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task AddOrderItemsAsync(List<OrderItem> items)
        {
            await _context.OrderItems.AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ChangeStatusAsync(int orderId, OrderStatus newStatus)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
                throw new Exception("there's no order");
            order.Status = newStatus;
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<Order>> GetAllWithUserAsync(string userId)
        {
            return await _context.Orders
                .Where(e => e.UserId == userId)
                .OrderByDescending(e => e.OrderDate)
                .ToListAsync();
        }

        public async Task<List<Order>> GetOrderStatusAsync(OrderStatus status)
        {
            return await _context.Orders
                .Where(e => e.Status == status)
                .OrderByDescending(e => e.OrderDate)
                .ToListAsync();
                
        }

        public async Task<Order> GetOneUserByOrderIdAsync(int orderId)
        {
            return await _context.Orders.FirstOrDefaultAsync(e => e.Id == orderId);
        }
    }
}
