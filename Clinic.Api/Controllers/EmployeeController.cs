using Clinic.Application.DTOs;
using Clinic.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [ApiController]
    [Route("api/employee")]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : ClinicBaseController
    {
        private readonly IEmployeeListService _employeelistService;
        public EmployeeController(IEmployeeListService employeelistService) 
        {
            _employeelistService = employeelistService; 
        }

        [HttpGet("List-Employees")]
        public async Task<IActionResult> EmployeeLists()
        {
            var result = await _employeelistService.GetEmployeeListAsync();
            return Ok(result);
        }

        [HttpGet("List-Doctors")]
        public async Task<IActionResult> GetDoctorsList()
        {
            var result = await _employeelistService.GetDoctorsAsync();
            return Ok(result);
        }
    }
}
