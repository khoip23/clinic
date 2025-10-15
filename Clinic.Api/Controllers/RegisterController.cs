using BCrypt.Net;
using Clinic.Application.DTOs;
using Clinic.Application.Interface;
using Clinic.Domain;
using Clinic.Domain.Entities;
using Clinic.Infrastructure;
using Clinic.Infrastructure.Helpers;
using Clinic.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _registerUserService;

        public RegisterController(IUserService registerUserService)
        {
            _registerUserService = registerUserService;
        }

        [HttpPost("patient")]
        public async Task<IActionResult> RegisterPatient([FromBody] RegisterUserDto dto)
        {
            if (dto.Role != RoleType.Patient)
                return BadRequest("Role not matching");

            var response = await _registerUserService.CreateUserAsync(dto);

            if(!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("employee")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterEmployee([FromBody] RegisterUserDto dto)
        {
            var response = await _registerUserService.CreateUserAsync(dto);

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
