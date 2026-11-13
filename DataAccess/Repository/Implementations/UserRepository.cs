using DataAccess.Data;
using DataAccess.Models;
using DataAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<bool> BlockUserAsync(string userId, int days)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return (false);
            user.LockoutEnd = DateTime.UtcNow.AddDays(days);
            var result =await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> ChangeUserRoleToAdmin(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new Exception("User Not Found");
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var item in userRoles)
            {
                if (item == "Admin")
                    return false;
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<List<ApplicationUser>> GetUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<bool> IsBlock(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new Exception("User Not Found");
            return user.LockoutEnd.HasValue && user.LockoutEnd > DateTime.UtcNow;
        }

        public async Task<bool> RemoveAdminRoleFromUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new Exception("User Not Found");
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var item in userRoles)
            {
                if(item == "Admin")
                {
                    await _userManager.RemoveFromRoleAsync(user, "Admin");
                    var result =await _userManager.UpdateAsync(user);
                    return result.Succeeded;
                }
               
            }
            return false;
        }
        public async Task<bool> UnBlockUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return false;
            user.LockoutEnd = null;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
    }
}
