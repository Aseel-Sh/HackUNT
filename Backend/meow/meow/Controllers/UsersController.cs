using Backend.Data.Data;
using Backend.Service.DTOs;
using Backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        public UsersController(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _userService.EmailExistsAsync(model.Email))
            {
                return BadRequest("Email already exists. Please use a different email.");
            }

            if (await _userService.UserNameExistsAsync(model.Username))
            {
                return BadRequest("Username already exists. Please use a different username");
            }

            try
            {
                await _userService.RegisterUserAsync(model);
                return Ok("User registered successfully");
            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while creating user");
            }
        }
    } 
}
