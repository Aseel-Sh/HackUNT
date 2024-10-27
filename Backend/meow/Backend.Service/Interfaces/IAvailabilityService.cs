using Backend.Data.Models;
using Backend.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.Interfaces
{
    public interface IAvailabilityService
    {
        Task CreateAvailabilityAsync(CreateAvailabilityDTO dto);
        Task<List<Availability>> GetAvailabilitiesByUserIdAsync(int userId);
    }
}
