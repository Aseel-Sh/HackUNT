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

            var CreatedMeeting = new Meeting
            {
                Title = DTO.Title, // This must be correctly assigned
                startTime = DTO.startTime,
                endTime = DTO.endTime,
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


        public async Task<List<Meeting>> GetAllMeetingsByUserIdAsync(int userId)
        {
            
                // Fetch all meetings created by the user with the specified user ID
                var meetings = await _context.Meetings
                    .Where(m => m.CreatedByUserID == userId) // Filter meetings where CreatedByUserID matches the userId
                    .ToListAsync();

                return meetings;
            
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




    }
} 

