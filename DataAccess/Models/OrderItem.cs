using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    [PrimaryKey(nameof(OrderId),nameof(ProductId))]
    public class OrderItem
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public decimal TotalPrice { get; set; }
        public int Count { get; set; }
    }
}
