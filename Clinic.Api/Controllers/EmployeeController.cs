using Clinic.Application.DTOs;
using Clinic.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [ApiController]
    [Route("api/employee")]
    //[Authorize(Roles = "Admin")]
    public class EmployeeController : ClinicBaseController
    {
        private readonly IEmployeeListService _employeelistService;
        public EmployeeController(IEmployeeListService employeelistService) 
        {
            _employeelistService = employeelistService; 
        }

        [HttpGet("list-employees")]
        public async Task<IActionResult> EmployeeList()
        {
            var result = await _employeelistService.GetEmployeeListAsync();
            return Ok(result);
        }

        [HttpGet("list-doctors")]
        public async Task<IActionResult> GetDoctorsList()
        {
            var result = await _employeelistService.GetDoctorsAsync();
            return Ok(result);
        }
    }
}
