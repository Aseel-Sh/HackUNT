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
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset startTime { get; set; }

        public DateTimeOffset endTime { get; set; }

        public int CreatedbyUserID { get; set; }

    }
}
