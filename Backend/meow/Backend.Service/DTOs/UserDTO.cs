using Backend.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.DTOs
{
    public class CreateUserDTO
    {
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string TimeZone { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public Roles Role { get; set; }
    }

    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string TimeZone { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public Roles Role { get; set; }
    }

    public class LoginUserDTO
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }

    }

    public class EditUserDTO
    {
        public int Id { get; set; } 
        public bool isActive { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
    }
}
