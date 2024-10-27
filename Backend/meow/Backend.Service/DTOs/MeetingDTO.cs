using Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.DTOs
{
    public class CreateMeetingDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public DateTimeOffset startTime { get; set; }
        public DateTimeOffset endTime { get; set; }
        public string Description { get; set; }
        public int CreatedByUserID { get; set; }
        public List<int> ParticipantIds { get; set; } = new List<int>(); 


    }
}