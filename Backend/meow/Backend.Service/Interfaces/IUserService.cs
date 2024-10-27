using Backend.Data.Models;
using Backend.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.Interfaces
{
    public interface IUserService
    {
        Task RegisterUserAsync(CreateUserDTO dto);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> UserNameExistsAsync(string userName);
        Task<User> ValidateUserAsync(string UsernameOrEmail, string password);
        public string GenerateJwtToken(User user);
        object GetUserResponse(User user);
        void UpdateUser(EditUserDTO userDTO);




    }
}
