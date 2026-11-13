using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.DTOs.Request
{
    public class CategoryRequestDTO
    {
        public Status Status = Status.Active;
        [Required]
        [MinLength(2, ErrorMessage = "The name must be more than 2 chars")]
        public string Name { get; set; }
    }
}
