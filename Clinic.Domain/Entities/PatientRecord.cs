using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class PatientRecord
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int ReceivedBy { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        [ForeignKey("Appointment")]
        public int? AppointmentId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
