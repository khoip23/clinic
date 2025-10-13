using Clinic.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application
{
    public interface IUserService
    {
        Task<RegisterResponeDto> RegisterUserAsync(DTOs.RegisterUserDto dto);
    }
}
