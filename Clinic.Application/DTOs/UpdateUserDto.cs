using Clinic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs
{
    public class UpdateUserDto
    {
        public string PhoneNumber { get; set; } = "";
        public string FullName { get; set; } = "";
        public DateTime? DOB { get; set; }
        public string Password { get; set; } = "";
    }
}
