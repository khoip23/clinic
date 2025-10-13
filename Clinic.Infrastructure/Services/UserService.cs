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

        public async Task<RegisterResponeDto> RegisterUserAsync(RegisterUserDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FullName))
                return new RegisterResponeDto
                {
                    IsSuccess = false,
                    ErrorMessage = "FullName cannot be blank!"
                };
            if (string.IsNullOrWhiteSpace(dto.PhoneNumber))
                return new RegisterResponeDto
                {
                    IsSuccess = false,
                    ErrorMessage = "PhoneNumber cannot be blank!"
                };
            if (string.IsNullOrWhiteSpace(dto.UserName))
                return new RegisterResponeDto
                {
                    IsSuccess = false,
                    ErrorMessage = "UserName cannot be blank!"
                };
            var usernameExists = await _context.Users.FirstOrDefaultAsync(u => u.UserName == dto.UserName);
            if (usernameExists != null)
                return new RegisterResponeDto
                {
                    IsSuccess = false,
                    ErrorMessage = "username already exists!"
                };

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

            return new RegisterResponeDto
            { 
                IsSuccess = true,
            };
        }
    }
}
