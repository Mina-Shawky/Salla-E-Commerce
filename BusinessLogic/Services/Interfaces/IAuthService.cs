using DataAccess.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<TokenDTO> LoginAsync(UserLoginDTO userLogin);
        public Task RegisterAsync(UserRegisterDTO userRegister);
        public Task<string> ConfirmEmail(string token, string userId);
        public Task<bool> ForgotPasswordAsync(ForgetPasswordDTO forgetPassword);
        public Task<bool> ResetPasswordAsync(ResetPasswordDTO resetPassword);
    }
}
