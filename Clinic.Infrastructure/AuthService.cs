using Clinic.Application;
using Clinic.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure
{
    public class AuthService : IAuthService
    {
        private readonly ClinicDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(ClinicDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<ResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.UserName == dto.UserName);
            if (user == null)
                throw new Exception("User not found");

            // Kiểm tra password (ở đây giả sử Password đã hash sẵn)
            if (user.Password != dto.Password) // 👉 ở thực tế thì phải hash để so sánh
                throw new Exception("Invalid password");

            var role = (RoleType)user.Role;

            // Sinh JWT
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Serect-Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:ExpireMinutes"])),
                signingCredentials: creds);

            return new ResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                FullName = user.FullName,
                Role = user.Role.ToString()
            };
        }
    }
}
