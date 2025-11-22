using Clinic.Application.DTOs;
using Clinic.Application.Interface;
using Clinic.Domain;
using Clinic.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Services
{
    public class EmployeeService : IEmployeeListService
    {
        private readonly ClinicDbContext _context;
        public EmployeeService(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeListDto>> GetEmployeeListByRolesAsync(params RoleType[] roles)
        {
            var role = roles.Select(r => (int)r).ToList();
            
            var employees = await _context.Users
                .Where(e => role.Contains(e.Role))
                .Select(e => new EmployeeListDto
                {
                    Id = e.Id,
                    UserName = e.UserName,
                    FullName = e.FullName,
                    DOB = e.DOB,
                    PhoneNumber = e.PhoneNumber,
                    // Password = e.Password, // 123123 => asdjioasjd;ọadoiajsiod
                    Role = (RoleType)e.Role
                })
            .ToListAsync();

            return employees;
        }

        public async Task<List<EmployeeListDto>> GetEmployeeListAsync()
        {
            return await GetEmployeeListByRolesAsync(RoleType.Receptionist, RoleType.Doctor);
        }

        public async Task<List<EmployeeListDto>> GetDoctorsAsync()
        {
            return await GetEmployeeListByRolesAsync(RoleType.Doctor);
        }
    }
}
