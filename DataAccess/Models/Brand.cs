using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Brand : BaseModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
