using Clinic.Application.DTOs;
using Clinic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Interface
{
    public interface IEmployeeListService
    {
        Task<List<EmployeeListDto>> GetEmployeeListAsync();
        Task<List<EmployeeListDto>> GetDoctorsAsync();
    }
}
