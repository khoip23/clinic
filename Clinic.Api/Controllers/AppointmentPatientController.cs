using Clinic.Application;
using Clinic.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Clinic.Api.Controllers
{
    [ApiController]
    [Route("api/getappointment-patient")]
    [Authorize(Roles = "Patient")]
    public class AppointmentPatientController : ControllerBase
    {
        private readonly IAppointmentPatientService _appointmentPatientService;

        public AppointmentPatientController(IAppointmentPatientService appointmentPatientService)
        {
            _appointmentPatientService = appointmentPatientService;
        }

        [HttpGet("Get-Appointment-Patient")]
        public async Task<IActionResult> GetAppointmentPatient([FromQuery] string status = "Active")
        {
            var patientIdGet = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(patientIdGet) || !int.TryParse(patientIdGet, out var patientId))
            { return Unauthorized(new { message = "Không tìm  thấy thông tin người dùng" }); }    
            

            var appointmentPatient = await _appointmentPatientService.GetAppointmentsForPatientAsync(patientId, status);
            return Ok(appointmentPatient);
        }
    }
}
