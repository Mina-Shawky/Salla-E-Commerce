using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string? City { get; set; }
        public string? StreetAddress { get; set; }
        public string? CodeResetPassword { get; set; }
        public DateTime? PasswordResetCodeExpiry { get; set; }

    }
}
