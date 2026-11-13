using BusinessLogic.Services.Interfaces;
using DataAccess.Models;
using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(
            IOrderRepository orderRepository
            )
        {
            _orderRepository = orderRepository;
        }
        public async Task AddOrderAsync(Order order)
        {
            await _orderRepository.AddOrderAsync(order);
        }

        public async Task<bool> ChangeStatusAsync(int orderId, OrderStatus newStatus)
        {
            var result = await _orderRepository.ChangeStatusAsync(orderId, newStatus);
            return result;
        }

        public async Task<List<Order>> GetAllWithUserAsync(string UserId)
        {
            return await _orderRepository.GetAllWithUserAsync(UserId);
        }

        public async Task<List<Order>> GetByStatusAsync(OrderStatus status)
        {
            return await _orderRepository.GetOrderStatusAsync(status);
        }

        public async Task<Order> GetUserByOrderId(int orderId)
        {
            return await _orderRepository.GetOneUserByOrderIdAsync(orderId);
        }
    }
}
