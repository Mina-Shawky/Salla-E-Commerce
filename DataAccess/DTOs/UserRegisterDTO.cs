using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DTOs
{
    public class UserRegisterDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
