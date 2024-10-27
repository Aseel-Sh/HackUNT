using Backend.Data.Data;
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
        public async Task <IActionResult> createAvailability(CreateAvailabilityDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                return BadRequest(new ApiResponseModel<string> { Status = false, Errors = errors });
            }

            try
            {
                await _availabilityService.CreateAvailabilityAsync(model);
                return Ok(new ApiResponseModel<string> {Data = "Availability Added Successfully"});
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponseModel<string> { Status = false, Message = "An error occurred while creating the user.", Errors = new List<string> { ex.Message } });
            }
        }
    }
}
