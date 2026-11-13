using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DTOs
{
    public class ResetPasswordDTO
    {
        public string NewPassword { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
    }
}
