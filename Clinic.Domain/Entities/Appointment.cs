using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int? DoctorId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Status { get; set; }
        public DateTime? VisittedAt { get; set; }
        public DateTime? CanceledAt { get; set; }

        public User User { get; set; }
        public User Doctor { get; set; }
    }
}
