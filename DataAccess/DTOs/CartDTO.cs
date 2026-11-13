using DataAccess.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DTOs
{
    public class CartDTO
    {
        public List<CartResponseDTO> Items { get; set; } = new List<CartResponseDTO>();
        public decimal TotalCart => Items.Sum(i => i.TotalPrice);
    }
}
