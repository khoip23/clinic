using Clinic.Application;
using Clinic.Application.DTOs;
using Clinic.Domain;
using Clinic.Infrastructure;
using Clinic.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var response = await _authService.LoginAsync(dto);

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }
    }
    
}
