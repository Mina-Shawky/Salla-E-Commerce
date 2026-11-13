using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DTOs.Response
{
    public class CategoryResponseDTO
    {
        public Status Status = Status.Active;
        public long Id { get; set; }
        public string? Name { get; set; }
    }
}
