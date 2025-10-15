using BCrypt.Net;
using Clinic.Application.DTOs;
using Clinic.Application.Interface;
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
        private readonly IRegisterUserService _userService;

        public RegisterController(IRegisterUserService userService)
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
