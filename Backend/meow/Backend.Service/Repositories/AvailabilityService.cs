using Backend.Data.Data;
using Backend.Data.Models;
using Backend.Service.DTOs;
using Backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.Repositories
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly ApplicationDbContext _context;
        public AvailabilityService(ApplicationDbContext content)
        {
            _context = content;
        }

        public async Task CreateAvailabilityAsync(CreateAvailabilityDTO dto)
        {
            if (dto.UserId == null)
            {
                throw new Exception("User Id cannot be null");
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == dto.UserId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (dto.StartTime == null || dto.EndTime == null)
            {
                throw new Exception("Start and End times cannot be null");
            }

            if (dto.EndTime <= dto.StartTime)
            {
                throw new Exception("End time must be after start time");
            }

            bool hasOverlap = await _context.Availabilities.AnyAsync(a =>
             a.UserId == dto.UserId &&
            ((dto.StartTime >= a.StartTime && dto.StartTime < a.EndTime) ||
            (dto.EndTime > a.StartTime && dto.EndTime <= a.EndTime) ||
            (dto.StartTime <= a.StartTime && dto.EndTime >= a.EndTime))
             );

            if (hasOverlap)
            {
                throw new Exception("Availability overlaps with an existing entry");
            }

            var availability = new Availability
            {
                UserId = dto.UserId,
                EndTime = dto.EndTime,
                StartTime = dto.StartTime
            };

            _context.Availabilities.Add(availability);
            await _context.SaveChangesAsync();

        }
    }
}
