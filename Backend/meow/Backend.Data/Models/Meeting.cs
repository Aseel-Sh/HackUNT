using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.Models
{
    public class Meeting
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]

        public string Description { get; set; }
        [Required]
        public DateTimeOffset startTime { get; set; }
        [Required]
        public DateTimeOffset endTime { get; set; }
        [Required]
        public int CreatedbyUserID { get; set; }
        public List<User> Users { get; set; } = new List<User>();

        public bool IsValidTimeRange()
        {
            return startTime < endTime;
        }

    }
}
