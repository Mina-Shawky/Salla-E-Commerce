using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> GetUserByOrderId(int orderId);
        public Task AddOrderAsync(Order order);
        public Task<List<Order>> GetByStatusAsync(OrderStatus status);
        public Task<List<Order>> GetAllWithUserAsync(string UserId);
        public Task<bool> ChangeStatusAsync(int orderId, OrderStatus newStatus);
    }
}
