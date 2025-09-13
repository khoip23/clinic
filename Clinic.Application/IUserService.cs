using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application
{
    public interface IUserService
    {
        Task<int> RegisterUserAsync(DTOs dto);
    }
}
