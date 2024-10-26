using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "File name cannot exceed 255 characters.")]
        public string FileName { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "File path cannot exceed 500 characters.")]
        public string FilePath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
