using Backend.Data.Data;
using Backend.Data.Models;
using Backend.Service.DTOs;
using Backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.Repositories
{
    public class MeetingRepo : IMeetingService
    {
        private readonly ApplicationDbContext _context;

        public MeetingRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateMeetingasync(CreateMeetingDTO DTO)
        {
            if (DTO == null)
            {
                throw new ArgumentNullException(nameof(DTO), "Meeting data cannot be null");
            }

            if (DTO.startTime >= DTO.endTime)
            {
                throw new ArgumentException("End time must be greater than start time.");
            }

            TimeZoneInfo userTimeZone;
            try
            {
                userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(DTO.TimeZone);
            }
            catch (TimeZoneNotFoundException)
            {
                throw new ArgumentException("The specified timezone was not found.");
            }
            catch (InvalidTimeZoneException)
            {
                throw new ArgumentException("The specified timezone is invalid.");
            }

            DateTimeOffset startTimeUtc = DTO.startTime.ToUniversalTime();
            DateTimeOffset endTimeUtc = DTO.endTime.ToUniversalTime();

            var CreatedMeeting = new Meeting
            {
                Title = DTO.Title, // This must be correctly assigned
                startTime = startTimeUtc,
                endTime = endTimeUtc,
                Description = DTO.Description,
                CreatedByUserID = DTO.CreatedByUserID
            };

            for (int i = 0; i < DTO.ParticipantIds.Count; i++)
            {
                var userId = DTO.ParticipantIds[i];
                var existingUser = await _context.Users.FindAsync(userId);

                if (existingUser != null)
                {
                    // Add the existing user to the meeting's Users list
                    CreatedMeeting.Users.Add(existingUser);
                }
            }

            _context.Meetings.Add(CreatedMeeting);
            await _context.SaveChangesAsync();
        }




        public async Task<bool> DeleteMeetingAsync(int meetingId)
        {
            Console.WriteLine($"Attempting to find Meeting with ID: {meetingId}");

            var meeting = await _context.Meetings
                .Include(m => m.Users)
                .AsTracking() // Ensure the entity is being tracked
                .FirstOrDefaultAsync(m => m.Id == meetingId);

            if (meeting == null)
            {
                Console.WriteLine($"Meeting with ID {meetingId} not found.");
                return false;
            }

            Console.WriteLine($"Meeting with ID {meetingId} found. Proceeding to delete.");

            // Remove associations first
            meeting.Users.Clear();
            await _context.SaveChangesAsync();

            // Remove the meeting itself
            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();

            Console.WriteLine($"Meeting with ID {meetingId} deleted successfully.");
            return true;
        }


        public async Task<List<MeetingWithLocalTimeDTO>> GetAllMeetingsByUserIdAsync(int userId, string TimeZone)
        {
            var userTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(TimeZone);

            // Fetch all meetings created by the user with the specified user ID
            var meetings = await _context.Meetings
                    .Where(m => m.CreatedByUserID == userId) // Filter meetings where CreatedByUserID matches the userId
                    .ToListAsync();

                return meetings.Select(meeting => new MeetingWithLocalTimeDTO
                {
                    Id = meeting.Id,
                    Title = meeting.Title,
                    Description = meeting.Description,
                    StartTimeUtc = meeting.startTime,
                    EndTimeUtc = meeting.endTime,
                    StartTimeLocal = TimeZoneInfo.ConvertTime(meeting.startTime, userTimeZoneInfo),
                    EndTimeLocal = TimeZoneInfo.ConvertTime(meeting.endTime, userTimeZoneInfo),
                    LocalTimeZone = TimeZone
                }).ToList();

        }


        public async Task<bool> UpdateMeetingAsync(int meetingId, Meeting updatedMeeting)
        {
            // Fetch the existing meeting
            var existingMeeting = await _context.Meetings.FirstOrDefaultAsync(m => m.Id == meetingId);

            if (existingMeeting == null)
            {
                return false; // Meeting not found
            }

            // Update the fields with the values from the updated meeting
            existingMeeting.Title = updatedMeeting.Title;
            existingMeeting.Description = updatedMeeting.Description;
            existingMeeting.startTime = updatedMeeting.startTime;
            existingMeeting.endTime = updatedMeeting.endTime;

            // Validate the new time range
            if (existingMeeting.startTime >= existingMeeting.endTime)
            {
                throw new ArgumentException("End time must be greater than start time.");
            }

            // Save changes to the database
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssignMeetingToParticipantAsync(int meetingId, int participantId, string participantTimeZone)
        {
            var meeting = await _context.Meetings.Include(m => m.Users).FirstOrDefaultAsync(m => m.Id == meetingId);

            if (meeting == null)
            {
                throw new Exception("Meeting not found.");
            }

            var participant = await _context.Users.FirstOrDefaultAsync(u => u.Id == participantId);
            if (participant == null)
            {
                throw new Exception("Participant not found.");
            }

            if (meeting.Users.Any(u => u.Id == participantId))
            {
                throw new Exception("Participant is already assigned to this meeting.");
            }

            meeting.Users.Add(participant);
            await _context.SaveChangesAsync();

            return true;
        }




    }
} 

