﻿using Backend.Data.Data;
using Backend.Data.Models;
using Backend.Service.DTOs;
using Backend.Service.Interfaces;
using Backend.Service.Repositories;
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
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                return BadRequest(new ApiResponseModel<string> { Status = false, Errors = errors });
            }

            if (await _userService.EmailExistsAsync(model.Email))
            {
                return BadRequest(new ApiResponseModel<string> { Message = "Email already exists. Please use a different email." });
            }

            if (await _userService.UserNameExistsAsync(model.Username))
            {
                return BadRequest(new ApiResponseModel<string> { Message = "Username already exists. Please use a different username" });
            }

            try
            {
                await _userService.RegisterUserAsync(model);
                return Ok(new ApiResponseModel<string> { Data = "User registered successfully" });
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponseModel<string> { Status = false, Message = "An error occurred while creating the user.", Errors = new List<string> { ex.Message } });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await _userService.ValidateUserAsync(model.UsernameOrEmail, model.Password);
                if (user == null)
                {
                    return Unauthorized("Invalid email, number, username, password, or user is inactive.");
                }

                var token = _userService.GenerateJwtToken(user);
                var userResponse = _userService.GetUserResponse(user);

                return Ok(new ApiResponseModel<object> { Data = new { Success = "Login successful", User = userResponse, Token = token } });
            }
            catch
            {
                return StatusCode(500, new ApiResponseModel<string> { Status = false, Message = "An error occurred while processing your request. Please try again later." });
            }

        }


        [HttpPut("user")]
        public IActionResult EditUser([FromBody] EditUserDTO userDTO)
        {
            try
            {
                _userService.UpdateUser(userDTO);
                return Ok(new ApiResponseModel<string> { Data = "User edited successfully" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponseModel<string> { Status = false, Message = ex.Message });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponseModel<string> { Status = false, Message = "Internal server error", Errors = new List<string> { ex.Message } });
            }
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                return Ok(new ApiResponseModel<List<UserDTO>> { Status = true, Message = "users retrieved successfully", Data = users });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponseModel<string> { Status = false, Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponseModel<string>
                { Status = false, Message = "An error occurred while retrieving users.", Errors = new List<string> { ex.Message } });
            }
        }
    } 

}
