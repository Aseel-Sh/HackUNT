using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.Models
{
    internal class Meeting
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Title { get; set; }
        public DateTimeOffset startTime { get; set; }

        public DateTimeOffset endTime { get; set; }

        public int CreatedbyUserID { get; set; }

        public User CreatedByUser { get; set; }
        public ICollection<MeetingParticipant> Participants { get; set; }

        public Meeting()
        {
            Participants = new HashSet<MeetingParticipant>();
        }

    }
}
