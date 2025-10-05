using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs
{
    public class PatientRecordHistoryDto
    {
        public int PatientRecordId { get; set; }
        public int PatientId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? AppointmentId { get; set; }
    }
}
