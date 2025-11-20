using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs
{
    public class CreateAppointmentRequestDto
    {
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int? DoctorId { get; set; }
    }
}
