using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs
{
    public class CreatePatientRecordInputDto
    {
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int? AppointmentId { get; set; }
    }
}
