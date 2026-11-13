using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DataAccess.DTOs.Response
{
    public class ProductResponseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public string MainImage { get; set; }
        public string MainImageUrl => $"https://localhost:44324/Images/{MainImage}";
    }
}
