using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<ApplicationUser>> GetUsersAsync();
        public Task<ApplicationUser> GetUserByIdAsync(string userId);
        public Task<bool> BlockUserAsync(string userId, int days);
        public Task<bool> UnBlockUserAsync(string userId);
        public Task<bool> IsBlock(string userId);
        public Task<bool> ChangeUserRoleToAdmin(string userId);
        public Task<bool> RemoveAdminRoleFromUser(string userId);
    }
}
