using Backend.Data.Data;
using Backend.Data.Models;
using Backend.Service.DTOs;
using Backend.Service.Interfaces;
using Backend.Service.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.Repositories
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;  
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task RegisterUserAsync(CreateUserDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Username) || dto.Username.Contains(" "))
            {
                throw new Exception("Username cannot be null or contain spaces.");
            }

            if (string.IsNullOrEmpty(dto.Password) || dto.Password.Contains(" "))
            {
                throw new Exception("Password cannot be null or contain spaces.");
            }

            var hashedPass = PasswordHasher.HashPassword(dto.Password);

            var user = new User
            {
                Username = dto.Username,
                Password = hashedPass,
                Email = dto.Email,
                TimeZone = dto.TimeZone,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,

            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

        }

        public Task<bool> UserNameExistsAsync(string userName)
        {
            return _context.Users.AnyAsync(x => x.Username == userName);
        }
    }
}
