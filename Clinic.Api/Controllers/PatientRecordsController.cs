using Clinic.Application;
using Clinic.Application.DTOs;
using Clinic.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Clinic.Api.Controllers
{
    [ApiController]
    [Route("api/CreatePatientRecord")]
    [Authorize(Roles = "Receptionist")]
    public class PatientRecordsController : ClinicBaseController
    {
        private readonly IPatientRecordService _patientRecordService;

        public PatientRecordsController(IPatientRecordService patientRecordService)
        {
            _patientRecordService = patientRecordService;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Receptionist,Admin")]
        public async Task<IActionResult> Create([FromBody] CreatePatientRecordInputDto input)
        {
            // Lấy id user đang đăng nhập (nhân viên tiếp nhận)
            var userId = GetCurrentUserId();
            if (userId == null)
                return Unauthorized(new { message = "User information not found" });

            var result = await _patientRecordService.CreatePatientRecordAsync(input, userId.Value);
            return Ok(result);
        }
    }
}
