using Clinic.Application;
using Clinic.Domain.Entities;
using Clinic.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Clinic.Domain;
using Clinic.Infrastructure.Helpers;

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
        public async Task<IActionResult> RegisterUser([FromBody] DTOs dto)
        {
            try
            {
                var userId = await _userService.RegisterUserAsync(dto);
                return Ok(new { message = "Tạo tài khoản thành công!", UserId = userId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
