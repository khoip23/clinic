using Clinic.Domain.Entities;
using Clinic.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ClinicDbContext _context;
        public UserController(ClinicDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<User>> Getall()
        {
            return await _context.User.ToListAsync();
        }
    }
}
