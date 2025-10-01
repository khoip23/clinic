using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs
{
    public class ResponseDto
    {
        public string Token { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}
