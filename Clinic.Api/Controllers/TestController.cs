using Clinic.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Authorize]
    public class TestController : ControllerBase
    {
        [HttpGet("patient-data")]
        [Authorize(Roles = nameof(RoleType.Patient))]
        public IActionResult ForPatient()
        {
            return Ok("Data for Patient");
        }

        [HttpGet("receptionist-data")]
        [Authorize(Roles = nameof(RoleType.Receptionist))]
        public IActionResult ForReceptionist()
        {
            return Ok("Data for Receptionist");
        }
        [HttpGet("Doctor-data")]
        [Authorize(Roles = nameof(RoleType.Doctor))]
        public IActionResult ForDoctor()
        {
            return Ok("Data for Doctor");
        }


        // for patient: 
        // for receptionist: 
        // for doctor:
    }
}
