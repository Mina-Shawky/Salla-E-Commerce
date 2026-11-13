using BusinessLogic.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using DataAccess.DTOs;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.Pkcs;
using System.Text;
using Microsoft.AspNetCore.Identity.Data;

namespace BusinessLogic.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;
        public AuthService(UserManager<ApplicationUser> userManager,IConfiguration configuration, IEmailSender emailSender)
        {
            _userManager = userManager;
            _configuration = configuration;
            _emailSender = emailSender;
        }
        public async Task<string> ConfirmEmail(string token, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new Exception("UserNot Found");
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if(result.Succeeded)
                return "Email Confirmed Success";
            return "Email confirmed Error";
        }

        public async Task<bool> ForgotPasswordAsync(ForgetPasswordDTO forgetPassword)
        {
            var user = await _userManager.FindByEmailAsync(forgetPassword.Email);
            if (user is null)
            {
                throw new Exception("User not found");
            }
            var random = new Random();
            var code = random.Next(1000, 9000).ToString();
            user.CodeResetPassword = code;
            user.PasswordResetCodeExpiry = DateTime.Now.AddMinutes(15);
            await _userManager.UpdateAsync(user);
            await _emailSender.SendEmailAsync(
                forgetPassword.Email,
                "Reset ur Password !!",
                $"<h1>Reset ur password and don't forgot it ! , the code is {code}</h1>"
                );
            return true;
        }

        public async Task<TokenDTO> LoginAsync(UserLoginDTO userLogin)
        {
            var user = await _userManager.FindByEmailAsync(userLogin.Email);
            if (user == null)
                throw new Exception("Email And Password Error");
            bool found = await _userManager.CheckPasswordAsync(user,userLogin.Password);
            if (!found)
                throw new Exception("Email And Password Error");
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name,user.UserName));
            claims.Add(new Claim(ClaimTypes.Email,user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier,user.Id));
            claims.Add(new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()));
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            SigningCredentials credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecretKey12345678901234567890")),SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwt = new JwtSecurityToken
            (
             issuer: "Salla.com",
             audience: "Salla.com",
             expires: DateTime.Now.AddDays(7),
             claims: claims,
             signingCredentials: credentials
            );
            return new TokenDTO { TokenString = new JwtSecurityTokenHandler().WriteToken(jwt) };
        }

        public async Task RegisterAsync(UserRegisterDTO userRegister)
        {
            var existUser = await _userManager.FindByEmailAsync(userRegister.Email);
            if (existUser != null)
                throw new Exception("The user already in");
            ApplicationUser user = new ApplicationUser
            {
                FullName = userRegister.FullName,
                UserName = userRegister.UserName,
                PhoneNumber = userRegister.PhoneNumber,
                Email = userRegister.Email,
                
            };
            var result = await _userManager.CreateAsync(user, userRegister.Password);
            if (result.Succeeded) 
            {
                await _userManager.AddToRoleAsync(user, "Customer");
            }
            else
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception(errors);
            }
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordDTO request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null) throw new Exception("User not found");
            if (user.CodeResetPassword != request.Code) throw new Exception("Code is not equal!");
            if (user.PasswordResetCodeExpiry < DateTime.Now) throw new Exception("Code expiry end!");
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);

            if (result.Succeeded)
            {
                await _emailSender.SendEmailAsync(
                   request.Email,
                   "Successfully change ur password!",
                   "Done saving ur new password ! in the next time save it plz"
                    );
            }
            return true;
        }
    }
}
