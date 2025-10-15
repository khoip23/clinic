using Clinic.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Interface
{
    public interface IUserService
    {
        Task<RegisterResponeDto> CreateUserAsync(RegisterUserDto dto);
        Task<RegisterResponeDto> UpdateEmployeeAsync(int userId, UpdateUserDto dto);
    }
}
