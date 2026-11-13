using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<UserDTO>> GetAllAsync();
        public Task<UserDTO> GetByIdAsync(string UserId);
        public Task<bool> BlockUserAsync(string UserId, int days);
        public Task<bool> UnBlockUserAsync(string UserId);
        public Task<bool> IsBlocked(string UserId);
        public Task<bool> ChangeUserRoleToAdmin(string UserId);
        public Task<bool> RemoveAdminRoleFromUser(string UserId);
    }
}
