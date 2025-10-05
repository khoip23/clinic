using Clinic.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [ApiController]
    [Route("api/GetPatientRecordHistory")]
    [Authorize(Roles = "Receptionist")]
    public class PatientRecordHistoryController : ControllerBase
    {
        private readonly IPatientRecordHistoryService _patientRecordHistoryService;
        public PatientRecordHistoryController(IPatientRecordHistoryService patientRecordHistoryService) 
        {
            _patientRecordHistoryService = patientRecordHistoryService;
        }

        [HttpGet("history/{userId}")]
        public async Task<IActionResult> GetHistory(int userId)
        {
            var records = await _patientRecordHistoryService.GetPatientRecordHistoryAsync(userId);
            return Ok(records);
        }
    }
}
