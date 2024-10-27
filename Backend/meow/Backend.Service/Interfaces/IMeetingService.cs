using Backend.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.Interfaces
{
    public interface IMeetingService
    {
        Task CreateMeetingasync(CreateMeetingDTO DTO);


        Task<bool> DeleteMeetingAsync(int meetingId);

        Task<List<Meeting>> GetAllMeetingsByUserIdAsync(int userId);

    }
}
