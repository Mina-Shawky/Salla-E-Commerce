using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order> GetOneUserByOrderIdAsync(int orderId);
        public Task AddOrderAsync(Order order);
        public Task AddOrderItemsAsync(List<OrderItem> items);
        public Task<List<Order>> GetOrderStatusAsync(OrderStatus status);
        public Task<List<Order>> GetAllWithUserAsync(string userId);
        public Task<bool> ChangeStatusAsync(int orderId, OrderStatus newStatus);
    }
}
