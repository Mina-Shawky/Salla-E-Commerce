using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DTOs.Request
{
    public class ProductRequestDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public int Quantity { get; set; }

        //img
        public IFormFile? MainImage { get; set; }

        public double? Rate { get; set; }
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
    }
}
