using DataAccess.DTOs.Request;
using DataAccess.DTOs.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Interfaces
{
    public interface ICheckOutService
    {
        public Task<CheckOutResponseDTO> ProcessPaymentAsync(CheckOutRequestDTO request, string UserId, HttpRequest httpRequest);
        public Task<bool> HandlePaymentSuccessAsync(int orderId);
    }
}
