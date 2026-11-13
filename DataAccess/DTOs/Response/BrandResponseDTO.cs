using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DataAccess.DTOs.Response
{
    public class BrandResponseDTO
    {
        public Status Status = Status.Active;
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public string Image { get; set; }
        public string MainImageUrl => $"https://localhost:44324/Images/{Image}";

    }
}
