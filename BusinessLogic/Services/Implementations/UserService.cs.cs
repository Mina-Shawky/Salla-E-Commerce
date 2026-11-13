using BusinessLogic.Services.Interfaces;
using DataAccess.DTOs;
using DataAccess.Repository.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> BlockUserAsync(string UserId, int days)
        {
            return await _userRepository.BlockUserAsync(UserId, days);
        }

        public async Task<bool> ChangeUserRoleToAdmin(string UserId)
        {
            return await _userRepository.ChangeUserRoleToAdmin(UserId);
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            return users.Adapt<List<UserDTO>>();
        }

        public async Task<UserDTO> GetByIdAsync(string UserId)
        {
            var user = await _userRepository.GetUserByIdAsync(UserId);
            return user.Adapt<UserDTO>();
        }

        public async Task<bool> IsBlocked(string UserId)
        {
            return await _userRepository.IsBlock(UserId);
        }

        public async Task<bool> RemoveAdminRoleFromUser(string UserId)
        {
            return await _userRepository.RemoveAdminRoleFromUser(UserId);
        }

        public Task<bool> UnBlockUserAsync(string UserId)
        {
            throw new NotImplementedException();
        }
    }
}
