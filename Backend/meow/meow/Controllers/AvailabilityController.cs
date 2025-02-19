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
    public class AvailabilityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAvailabilityService _availabilityService;
        public AvailabilityController(ApplicationDbContext context, IAvailabilityService availability)
        {
            _context = context;
            _availabilityService = availability;
        }

        [HttpPost("createAvailability")]
        public async Task<IActionResult> createAvailability([FromBody] CreateAvailabilityDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                return BadRequest(new ApiResponseModel<string> { Status = false, Errors = errors });
            }

            try
            {
                await _availabilityService.CreateAvailabilityAsync(model);
                return Ok(new ApiResponseModel<string> { Data = "Availability Added Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponseModel<string> { Status = false, Message = "An error occurred while creating the user.", Errors = new List<string> { ex.Message } });
            }
        }

        [HttpGet("user/{UserId}")]
        public async Task<IActionResult> GetAvailabilityByUserId(int UserId)
        {
            try
            {
                var availabilities = await _availabilityService.GetAvailabilitiesByUserIdAsync(UserId);
                return Ok(new ApiResponseModel<List<Availability>> { Status = true, Message = "Availabilities retrieved successfully", Data = availabilities });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponseModel<string> { Status = false, Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponseModel<string>
                { Status = false, Message = "An error occurred while retrieving availabilities.", Errors = new List<string> { ex.Message } });
            }
        }

        [HttpPut("availability")]
        public IActionResult EditAvailability([FromBody] EditAvailabilityDTO availabilityDto)
        {
            try
            {
                _availabilityService.UpdateAvailability(availabilityDto);
                return Ok(new ApiResponseModel<string> { Status = true, Message = "Availability Edited Successfully" });
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

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAvailability(int id)
        {
            try
            {
                await _availabilityService.DeleteAvailabilityAsync(id);
                return Ok(new ApiResponseModel<string>
                {
                    Status = true,
                    Message = "Availability deleted successfully"
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponseModel<string>
                {
                    Status = false,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponseModel<string>
                {
                    Status = false,
                    Message = "An error occurred while deleting availability.",
                    Errors = new List<string> { ex.Message }
                });
            }
        }
    }
}
