using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public enum OrderStatus
    {
        Pending = 1,
        Canceled = 2,
        Approved = 3,
        Shipped = 4,
        Delivered = 5
    }
    public enum PaymentMethod
    {
        Cash = 1,
        Visa = 2
    }
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime ShippedDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string? PaymentId { get; set; }
        public string? CarrierName { get; set; }
        public string? TrackingNumber { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
