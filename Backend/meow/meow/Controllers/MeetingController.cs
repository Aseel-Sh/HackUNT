using Backend.Data.Data;
using Backend.Service.DTOs;
using Backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    { 
        private readonly ApplicationDbContext _context; 
        private readonly IMeetingService _meetingService;

        public MeetingController(ApplicationDbContext context, IMeetingService meetingService)
        {
            _context = context; 
            _meetingService = meetingService;

        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateMeeting([FromBody] CreateMeetingDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _meetingService.CreateMeetingasync(dto);

            return Ok(new { message = "Meeting created successfully." });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeeting(int id)
        {
            var result = await _meetingService.DeleteMeetingAsync(id);

            if (!result)
            {
                return NotFound(new { message = "Meeting not found." });
            }

            return Ok(new { message = "Meeting deleted successfully." });
        }


        [HttpGet("user/{userId}/meetings")]
        public async Task<IActionResult> GetMeetingsByUserId(int userId)
        {
            try
            {
                var meetings = await _meetingService.GetAllMeetingsByUserIdAsync(userId);
                return Ok(meetings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPut("{meetingId}")]
        public async Task<IActionResult> UpdateMeeting(int meetingId, [FromBody] Meeting updatedMeeting)
        {
            try
            {
                var result = await _meetingService.UpdateMeetingAsync(meetingId, updatedMeeting);
                if (!result)
                {
                    return NotFound($"Meeting with ID {meetingId} not found.");
                }

                return Ok("Meeting updated successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
