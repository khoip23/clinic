using BCrypt.Net;
using Clinic.Application;
using Clinic.Application.DTOs;
using Clinic.Domain;
using Clinic.Domain.Entities;
using Clinic.Infrastructure;
using Clinic.Infrastructure.Helpers;
using Clinic.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto dto)
        {
            var response = await _userService.RegisterUserAsync(dto);

            if(!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
