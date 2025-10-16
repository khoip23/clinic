using Clinic.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs
{
    public class EmployeeListDto
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public RoleType Role { get; set; }
        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
    }
}
