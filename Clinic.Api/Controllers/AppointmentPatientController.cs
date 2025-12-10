using Clinic.Application.DTOs;
using Clinic.Application.Interface;
using Clinic.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Clinic.Api.Controllers
{
    [ApiController]
    [Route("api/getappointment-patient")]
    [Authorize(Roles = "Patient")]
    public class AppointmentPatientController : ClinicBaseController
    {
        private readonly IAppointmentPatientService _appointmentPatientService;

        public AppointmentPatientController(IAppointmentPatientService appointmentPatientService)
        {
            _appointmentPatientService = appointmentPatientService;
        }

        [HttpGet("Get-Appointment-Patient")]
        public async Task<IActionResult> GetAppointmentPatient([FromQuery] StatusAppointment? status = StatusAppointment.Active)
        {
            var patientId = GetCurrentUserId();
            // validation
            if (patientId == null)
            { 
                return Unauthorized(new { message = "User information not found" }); 
            }    
            var appointmentPatient = await _appointmentPatientService.GetAppointmentsForPatientAsync(patientId.Value, status);
            return Ok(appointmentPatient);
        }

        [HttpPut("Cancel/{appointmentId}")]
        public async Task<IActionResult> CancelAppointment(int appointmentId)
        {
            var patientId = GetCurrentUserId();
            if (patientId == null)
                return Unauthorized(new { message = "Thông tin người dùng không tồn tại" });

            var result = await _appointmentPatientService.CancelAppointmentAsync(appointmentId, patientId.Value);

            if (!result)
                return NotFound(new { message = "Không tìm thấy lịch hẹn hoặc bạn không có quyền hủy." });

            return Ok(new { message = "Hủy lịch hẹn thành công." });
        }
    }
}
