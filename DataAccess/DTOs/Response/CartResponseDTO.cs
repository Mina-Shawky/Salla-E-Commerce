using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DTOs.Response
{
    public class CartResponseDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set;}
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice => Price * Count;
    }
}
