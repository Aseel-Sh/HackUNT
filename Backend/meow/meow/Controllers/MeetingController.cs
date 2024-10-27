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


        [HttpGet("GetMeetingsByUserId")]
        public async Task<IActionResult> GetMeetingsByUserId(int userId, string timeZone)
        {
            try
            {
                var meetings = await _meetingService.GetAllMeetingsByUserIdAsync(userId, timeZone);

                return Ok(new
                {
                    Status = true,
                    Message = "Meetings retrieved successfully",
                    Data = meetings
                });
            }
            catch (TimeZoneNotFoundException)
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = "The specified timezone was not found."
                });
            }
            catch (InvalidTimeZoneException)
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = "The specified timezone is invalid."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Status = false,
                    Message = "An error occurred while retrieving meetings.",
                    Error = ex.Message
                });
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
