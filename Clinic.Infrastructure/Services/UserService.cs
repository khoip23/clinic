using Clinic.Application;
using Clinic.Domain.Entities;
using Clinic.Domain;
using Clinic.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Application.DTOs;

namespace Clinic.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ClinicDbContext _context;

        public UserService(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task<int> RegisterUserAsync(DTOs dto)
        {
            if (await _context.Users.AnyAsync(u => u.UserName == dto.UserName))
                throw new Exception("Tên tài khoản này đã tồn tại");

            var user = new User
            {
                PhoneNumber = dto.PhoneNumber,
                FullName = dto.FullName,
                DOB = dto.DOB,
                UserName = dto.UserName,
                Password = PasswordHelper.HashPassword(dto.Password),
                Role = (int)RoleType.Patient
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }
    }
}
