using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTimeOffset TimeZone { get; set; }
        public bool isActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Attachment> Attachments { get; set; } = new List<Attachment>();

        public List<Meeting> Meetings { get; set; } = new List<Meeting>();

        public List<Availability> Availabilities { get; set; } = new List<Availability>();

       
    }
}
