using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Clinic.Api.Controllers
{
    public class ClinicBaseController : ControllerBase
    {
        protected int? GetCurrentUserId()
        {
            var idStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(idStr) && !int.TryParse(idStr, out var userId))
            { 
                return userId; 
            }
            return null;
        }
    }
}
