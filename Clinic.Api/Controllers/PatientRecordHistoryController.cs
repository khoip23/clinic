using Clinic.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Clinic.Api.Controllers
{
    [ApiController]
    [Route("api/GetPatientRecordHistory")]
    [Authorize(Roles = "Patient")]
    public class PatientRecordHistoryController : ControllerBase
    {
        private readonly IPatientRecordHistoryService _patientRecordHistoryService;
        public PatientRecordHistoryController(IPatientRecordHistoryService patientRecordHistoryService) 
        {
            _patientRecordHistoryService = patientRecordHistoryService;
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var records = await _patientRecordHistoryService.GetPatientRecordHistoryAsync(userId);
            return Ok(records);
        }
    }
}
