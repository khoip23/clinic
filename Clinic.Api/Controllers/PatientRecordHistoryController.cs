using Clinic.Application;
using Clinic.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Clinic.Api.Controllers
{
    [ApiController]
    [Route("api/GetPatientRecordHistory")]
    [Authorize(Roles = "Patient")]
    public class PatientRecordHistoryController : ClinicBaseController
    {
        private readonly IPatientRecordHistoryService _patientRecordHistoryService;
        public PatientRecordHistoryController(IPatientRecordHistoryService patientRecordHistoryService) 
        {
            _patientRecordHistoryService = patientRecordHistoryService;
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            var userId = GetCurrentUserId();
            if (userId == null)
            {
                return Unauthorized(new { message = "Không tìm thấy thông tin người dùng" });
            }

            var records = await _patientRecordHistoryService.GetPatientRecordHistoryAsync(userId.Value);
            return Ok(records);
        }
    }
}
