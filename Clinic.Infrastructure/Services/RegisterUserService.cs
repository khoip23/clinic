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
using Clinic.Application.Interface;

namespace Clinic.Infrastructure.Services
{
    public class RegisterUserService : IUserService
    {
        private readonly ClinicDbContext _context;

        public RegisterUserService(ClinicDbContext context)
        {
            _context = context;
        }
        public async Task<RegisterResponeDto> CreateUserAsync(RegisterUserDto dto)
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

            var usernameExists = await _context.Users.AnyAsync(u => u.UserName == dto.UserName);
            if (usernameExists)
                return new RegisterResponeDto
                {
                    IsSuccess = false,
                    ErrorMessage = "Username already exists!"
                };

            var user = new User
            {
                FullName = dto.FullName,
                PhoneNumber = dto.PhoneNumber,
                DOB = dto.DOB,
                UserName = dto.UserName,
                Password = PasswordHelper.HashPassword(dto.Password),
                Role = (int)dto.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new RegisterResponeDto
            {
                IsSuccess = true,
            };
        }

        public async Task<RegisterResponeDto> UpdateEmployeeAsync(int userId, UpdateUserDto dto)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return new RegisterResponeDto
                {
                    IsSuccess = false,
                    ErrorMessage = "User not found!"
                };

            if(!string.IsNullOrWhiteSpace(dto.FullName))
                user.FullName = dto.FullName;
            if(dto.DOB.HasValue)
                user.DOB = dto.DOB.Value;
            if(!string.IsNullOrWhiteSpace(dto.PhoneNumber))
                user.PhoneNumber = dto.PhoneNumber;
            if (!string.IsNullOrWhiteSpace(dto.Password))
                user.Password = PasswordHelper.HashPassword(dto.Password);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new RegisterResponeDto
            {
                IsSuccess = true,
            };
        }      
    }
}
