using Clinic.Application;
using Clinic.Domain;
using Clinic.Infrastructure;
using Clinic.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ClinicDbContext _context;

        public LoginController(IAuthService authService, ClinicDbContext context)
        {
            _authService = authService;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto, [FromServices] IConfiguration config)
        {
            if (string.IsNullOrWhiteSpace(dto.UserName) || string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest(new { message = "Username hoặc password không được để trống" });

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == dto.UserName);
            if (user == null)
                return Unauthorized(new { message = "Sai username hoặc password" });

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
            if (!isPasswordValid)
                return Unauthorized(new { message = "Sai username hoặc password" });

            var roleName = ((RoleType)user.Role).ToString();    

            var token = JwtHelper.GenerateJwtToken(user.Id.ToString(), user.UserName, roleName, config);

            return Ok(new
            {
                message = "Đăng nhập thành công!",
                token = token
            });
        }
    }
}
