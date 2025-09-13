using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application
{
    public interface IAuthService
    {
        Task<ResponseDto> LoginAsync(LoginDto dto);
    }
}
