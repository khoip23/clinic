using Clinic.Application.Interface;
using Clinic.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [ApiController]
    [Route("api/appointment-receptionist")]
    [Authorize(Roles = "Receptionist")]
    public class AppointmentReceptionistController : ControllerBase
    {
        private readonly IAppointmentReceptionistService _appointmentreceptionistservice;
        public AppointmentReceptionistController(IAppointmentReceptionistService appointmentreceptionistservice)
        {
            _appointmentreceptionistservice = appointmentreceptionistservice;
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchAppointment(int? userId, string patientName, StatusAppointment? status = StatusAppointment.Active)
        {
            var result = await _appointmentreceptionistservice.SearchAppointmentsAsync(userId, patientName, status);
            return Ok(new { success = true, data = result });
        }
    }
}
