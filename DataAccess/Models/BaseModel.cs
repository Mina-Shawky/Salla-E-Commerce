using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public enum Status { Active = 1, InActive = 2}
    public class BaseModel
    {
        public int Id { get; set; }
        public Status Status { get; set; } = Status.Active;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
