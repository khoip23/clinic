using Clinic.Application.DTOs;
using Clinic.Application.Interface;
using Clinic.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Clinic.Api.Controllers
{
    [ApiController]
    [Route("api/appointment")]
    public class AppointmentController : ClinicBaseController
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService) 
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentRequestDto request)
        {
            try
            {
                var UserId = GetCurrentUserId();
                // validation
                if (UserId == null)
                {
                    return Unauthorized(new { message = "User information not found" });
                }

                var appointment = await _appointmentService.CreateAppointmentAsync(UserId.Value, request);

                return Ok(appointment);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new {message = ex.Message});
            }
        }
    }
}
