using Backend.Data.Data;
using Backend.Data.Models;
using Backend.Service.DTOs;
using Backend.Service.Interfaces;
using Backend.Service.Utility;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Backend.Data.Models.Enums;
using static Backend.Service.DTOs.AttachmentDTO;

namespace Backend.Service.Repositories
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IAttachmentService _attachmentService;


        public UserService(ApplicationDbContext context, IConfiguration configuration, IAttachmentService attachmentService)
        {
            _context = context;  
            _configuration = configuration;
            _attachmentService = attachmentService;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);


            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
            }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiresInMinutes"])),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public object GetUserResponse(User user)
        {
            return new
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
            };
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
                roles = dto.Role,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,

            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            if (!string.IsNullOrEmpty(dto.FilePath) && !string.IsNullOrEmpty(dto.FileName))
            {
                var createUserAttachmentDTO = new CreateUserAttachmentDTO
                {
                    UserId = user.Id,
                    FileName = dto.FileName,
                    FilePath = dto.FilePath
                };

                try
                {
                    _attachmentService.UploadUserProfilePicture(createUserAttachmentDTO);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    throw new Exception("Failed to upload image: " + ex.Message);
                }

            }
        }

        public Task<bool> UserNameExistsAsync(string userName)
        {
            return _context.Users.AnyAsync(x => x.Username == userName);
        }

        public async Task<User> ValidateUserAsync(string UsernameOrEmail, string password)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(u => 
                (u.Username == UsernameOrEmail || u.Email == UsernameOrEmail) && u.isActive);

            if (user == null || !PasswordHasher.VerifyPassword(password, user.Password))
            {
                return null;
            }

            return user;
        }

        public void UpdateUser(EditUserDTO userDTO)
        {
            var user = _context.Users.FirstOrDefault(a => a.Id == userDTO.Id);
            if (user == null)
            {
                throw new Exception("User with that ID not found");
            }

            user.isActive = userDTO.isActive;

            if (!string.IsNullOrEmpty(userDTO.FilePath) && !string.IsNullOrEmpty(userDTO.FileName))
            {
                var existingAttachment = _context.Attachments.FirstOrDefault(a => a.UserId == userDTO.Id);
                if (existingAttachment != null)
                {
                    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "Attachments", existingAttachment.FileName);
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }

                    _context.Attachments.Remove(existingAttachment);
                }

                var newImageFileName = _attachmentService.UploadUserProfilePicture(new CreateUserAttachmentDTO
                {
                    UserId = userDTO.Id,
                    FileName = userDTO.FileName,
                    FilePath = userDTO.FilePath 
                });
            }

            _context.Users.Update(user);
            _context.SaveChanges();

        }

        public async Task<List<UserDTO>> GetUsersAsync()
        {
            var users =  await _context.Users.Select(u => new UserDTO{
                                                Id = u.Id,
                                                Username = u.Username,
                                                Email = u.Email,
                                                TimeZone = u.TimeZone,
                                                Role = u.roles,
                                                FileName = u.Attachments.Select(a => a.FileName).FirstOrDefault(),
                                                FilePath = u.Attachments.Select(a => a.FilePath).FirstOrDefault(),

                                              }).ToListAsync();
            if (users == null || users.Count == 0)
            {
                throw new KeyNotFoundException("No users found");
            }

            return users;

        }


    }
}
