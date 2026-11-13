using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DTOs.Response
{
    public class CheckOutResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string? Url { get; set; }
        public string? PaymentId { get; set; }
    }
}
