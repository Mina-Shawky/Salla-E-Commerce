using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set;}
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
