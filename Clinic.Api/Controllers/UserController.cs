using Clinic.Application;
using Clinic.Domain.Entities;
using Clinic.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Clinic.Domain;

namespace Clinic.Api.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ClinicDbContext _context;
        public UserController(ClinicDbContext context)
        {
            _context = context;
        }
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody]DTOs dto)
        {
            if(await _context.User.AnyAsync(u => u.UserName == dto.UserName))
            {
                return BadRequest(new { message = "tên tài khoản này đã tồn tại" });
            }    

            //hàm băm pass
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User
            {
                UserName = dto.UserName,
                Password = hashedPassword,
                FullName = dto.FullName,
                DOB = dto.DOB,
                Role = (int)RoleType.Patient
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return Ok(new {message = "Tạo tài khoản thành công!", UserId = user.Id});
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Getall()
        {
            return await _context.User.ToListAsync();
        }
    }
}
