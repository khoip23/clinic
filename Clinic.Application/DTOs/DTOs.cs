using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs
{
    public class DTOs
    {
        public string PhoneNumber { get; set; } = "";
        public string FullName { get; set; } = "";
        public DateTime DOB { get; set; }
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        
        
    }

    //public class LoginDto
    //{
    //    public string UserName { get; set; } = "";
    //    public string Password { get; set; } = "";
    //}

    //public class ResponseDto
    //{
    //    public string Token { get; set; }
    //    public string FullName { get; set; }
    //    public string Role { get; set; }
    //}

    //public class CreateAppointmentRequest
    //{
    //    public DateTime Date { get; set; }
    //    public TimeSpan Time { get; set; }
    //    public int? DoctorId { get; set; }
    //}

    //public class AppointmentPatientDto
    //{
    //    public int Id { get; set; }
    //    public DateOnly Date { get; set; }
    //    public TimeOnly Time { get; set; }
    //    public int Status { get; set; }
    //    public int? DoctorId { get; set; }
    //}

    //public class AppointmentReceptionistDto
    //{
    //    public int Id { get; set; }
    //    public DateOnly Date { get; set; }
    //    public TimeOnly Time { get; set; }
    //    public int Status { get; set; }
    //    public int? DoctorId { get; set; }
    //}
}
