using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs
{
    public class CreateAppointmentRequest
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int? DoctorId { get; set; }
    }
}
