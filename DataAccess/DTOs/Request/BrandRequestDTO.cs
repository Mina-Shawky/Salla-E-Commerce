using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.DTOs.Request
{
    public class BrandRequestDTO
    {
        public Status Status = Status.Active;
        [Required]
        [MinLength(2,ErrorMessage = "Brand name must be at least 2 characters long.")]
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}
