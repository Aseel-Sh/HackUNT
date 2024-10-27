using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.Models
{
    public class Availability
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTimeOffset StartTime { get; set; }
        [Required]
        public DateTimeOffset EndTime { get; set; }

        public List<User> Users { get; set; } = new List<User>();


        // Ensure StartTime is before EndTime
        public bool IsValidTimeRange()
        {
            return StartTime < EndTime;
        }

    }
}
