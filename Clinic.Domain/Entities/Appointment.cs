using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        [ForeignKey("User")]
        public int? DoctorId { get; set; }
        public User Doctor { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Status { get; set; }
        public DateTime? VisittedAt { get; set; }
        public DateTime? CanceledAt { get; set; }

        
        
    }
}
